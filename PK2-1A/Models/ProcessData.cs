using EasyModbus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using cip_blue.Attributes;

namespace cip_blue.Models
{
    public abstract class ProcessData : INotifyPropertyChanged
    {
        public Action<ModbusWriteItem> RequestModbusWrite;

        private DateTime _DTS;
        public DateTime DTS
        {
            get { return _DTS; }
            set
            {
                if (_DTS != value)
                {
                    _DTS = value;
                    notifyPropertyChanged("DTS");
                }
            }
        }

        // CONST
        public readonly int InputCount;
        public readonly int CoilCount;
        public readonly int InputRegisterCount;
        public readonly int HoldigRegisterCount;


        public bool ModbusWriteCompleted = true;

        private readonly Dictionary<string, object> fields;
        private readonly List<PropertyInfo> propertiesInfo;




        public ProcessData()
        {
            //operPropertyChanged = AsyncOperationManager.CreateOperation(null);

            propertiesInfo = new List<PropertyInfo>();
            fields = new Dictionary<string, object>();

            foreach (PropertyInfo prop in GetType().GetProperties().Where(p => p.PropertyType.IsPrimitive))
            {
                propertiesInfo.Add(prop);

                fields.Add(prop.Name, Activator.CreateInstance(prop.PropertyType));

                TypeCode typeCode = Type.GetTypeCode(prop.PropertyType);
                switch (typeCode)
                {
                    case TypeCode.Boolean:
                        if (prop.CanWrite) CoilCount++; else InputCount++;
                        break;
                    case TypeCode.UInt16:
                        if (prop.CanWrite) HoldigRegisterCount++; else InputRegisterCount++;
                        break;
                    case TypeCode.Int16:
                        if (prop.CanWrite) HoldigRegisterCount++; else InputRegisterCount++;
                        break;
                    case TypeCode.UInt32:
                        if (prop.CanWrite) HoldigRegisterCount = HoldigRegisterCount + 2; else InputRegisterCount = InputRegisterCount + 2;
                        break;
                    case TypeCode.Int32:
                        if (prop.CanWrite) HoldigRegisterCount = HoldigRegisterCount + 2; else InputRegisterCount = InputRegisterCount + 2;
                        break;
                    case TypeCode.Single:
                        if (prop.CanWrite) HoldigRegisterCount = HoldigRegisterCount + 2; else InputRegisterCount = InputRegisterCount + 2;
                        break;

                    default:
                        throw new InvalidEnumArgumentException("Unknow modbus type!");
                }
            }
        }

        protected T getValue<T>([CallerMemberName] string property = "")
        {
            if (fields.ContainsKey(property))
                return (T)Convert.ChangeType(fields[property], typeof(T));
            else
                return default(T);
        }

        protected void setValue<T>(T value, [CallerMemberName] string property = "")
        {
            ModbusWriteCompleted = false;

            fields[property] = (T)Convert.ChangeType(value, typeof(T));

            ModbusWriteItem item = new ModbusWriteItem();
            int idx = 0;
            if (typeof(T) == typeof(bool))
            {
                item.Distination = Distination.COIL;

                //foreach (PropertyInfo prop in GetType().GetProperties().Where(p => p.PropertyType.IsPrimitive && p.PropertyType == typeof(bool) && p.CanWrite))
                foreach (PropertyInfo prop in propertiesInfo.Where(p => p.PropertyType == typeof(bool) && p.CanWrite))
                {
                    if (prop.Name == property) break;
                    idx++;
                }

                item.Addr = idx;
                item.Val = value;
            }
            else
            {
                item.Distination = Distination.HOLDING;

                //foreach (PropertyInfo prop in GetType().GetProperties().Where(p => p.PropertyType.IsPrimitive && p.PropertyType != typeof(bool) && p.CanWrite))
                foreach (PropertyInfo prop in propertiesInfo.Where(p => p.PropertyType != typeof(bool) && p.CanWrite))
                {
                    if (prop.Name == property) item.Addr = idx;

                    TypeCode typeCode = Type.GetTypeCode(prop.PropertyType);
                    switch (typeCode)
                    {
                        case TypeCode.UInt16:
                            idx++; item.Val = new int[] { Convert.ToInt16(value) };
                            break;
                        case TypeCode.Int16:
                            idx++; item.Val = new int[] { Convert.ToInt16(value) };
                            break;
                        case TypeCode.UInt32:
                            idx = idx + 2; item.Val = ModbusClient.ConvertIntToRegisters(Convert.ToInt32(value));
                            break;
                        case TypeCode.Int32:
                            idx = idx + 2; item.Val = ModbusClient.ConvertIntToRegisters(Convert.ToInt32(value));
                            break;
                        case TypeCode.Single:
                            idx = idx + 2; item.Val = ModbusClient.ConvertFloatToRegisters(Convert.ToSingle(value));
                            break;
                    }

                    if (prop.Name == property) break;
                }

            }

            RequestModbusWrite?.Invoke(item);
        }

        internal void ExternalSet(int[] values)
        {
            if (ModbusWriteCompleted)
            {
                int idx = 0;
                //string s = String.Empty;
                //foreach (PropertyInfo prop in GetType().GetProperties().Where(p => p.PropertyType.IsPrimitive))
                foreach (PropertyInfo prop in propertiesInfo)
                {
                    Single div = 1;
                    DeviderAttribute attr = (DeviderAttribute)Attribute.GetCustomAttribute(prop, typeof(DeviderAttribute));
                    if (attr != null) div = attr.Devider;

                    TypeCode typeCode = Type.GetTypeCode(prop.PropertyType);
                    switch (typeCode)
                    {
                        case TypeCode.Boolean:
                            fields[prop.Name] = Convert.ToBoolean(values[idx]);
                            //Debug.WriteLine(prop.Name + " " + Convert.ToBoolean(values[idx]));
                            idx = idx + 1;
                            break;
                        case TypeCode.UInt16:
                            fields[prop.Name] = (UInt16)values[idx] / div;
                            idx = idx + 1;
                            break;
                        case TypeCode.Int16:
                            fields[prop.Name] = (Int16)values[idx] / div;
                            idx = idx + 1;
                            break;
                        case TypeCode.UInt32:
                            fields[prop.Name] = ModbusClient.ConvertRegistersToInt(values.Skip(idx).Take(2).ToArray()) / div;
                            idx = idx + 2;
                            break;
                        case TypeCode.Int32:
                            fields[prop.Name] = ModbusClient.ConvertRegistersToInt(values.Skip(idx).Take(2).ToArray()) / div;
                            idx = idx + 2;
                            break;
                        case TypeCode.Single:
                            fields[prop.Name] = ModbusClient.ConvertRegistersToFloat(values.Skip(idx).Take(2).ToArray()) / div;
                            idx = idx + 2;
                            break;

                        default:
                            throw new InvalidEnumArgumentException("Modbus data not sync ... Unknow modbus type!");
                    }

                    //s += "," + prop.Name;
                    notifyPropertyChanged(prop.Name);
                    //Debug.WriteLine(prop.Name);
                }

                //notifyPropertyChanged(s);
            }


        }

        #region INotifyPropertyChanged Members

        //private AsyncOperation operPropertyChanged;
        //private event PropertyChangedEventHandler propertyChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        private void notifyPropertyChanged(string propertyName)
        {
            //this.operPropertyChanged.Post(this.notifyPropertyChangedSynced, propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            //if (this.PropertyChanged != null && state is string)
            //{
            //    string[] sa = ((string)state).Split(',');
            //    foreach (string s in sa)
            //        this.propertyChanged(this, new PropertyChangedEventArgs(s));
            //}
        }

        //private void notifyPropertyChangedSynced(object state)
        //{
        //    if (this.propertyChanged != null && state is string)
        //    {
        //        string[] sa = ((string)state).Split(',');
        //        foreach (string s in sa)
        //            this.propertyChanged(this, new PropertyChangedEventArgs(s));
        //    }
        //}


        //event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        //{
        //    add { this.propertyChanged += value; }
        //    remove { this.propertyChanged -= value; }
        //}
        #endregion

    }

}
