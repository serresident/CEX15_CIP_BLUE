using belofor.Events;
using cip_blue.Events;
using cip_blue.Models;
using cip_blue.Services;
using EasyModbus;
using EasyModbus.Exceptions;
using NLog;
using Prism.Events;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace PK2.Services
{
    public class ModbusMasterService : BackgroundService
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        ConcurrentQueue<ModbusWriteItem> requestToWrite = new ConcurrentQueue<ModbusWriteItem>();

        ModbusClient modbusClient;

        ProcessData processData;
        IEventAggregator eventAggregator;

        public ModbusMasterService(ProcessData processData, IEventAggregator eventAggregator) : base()
        {
            this.processData = processData;
            this.eventAggregator = eventAggregator;
        }

        protected override void Execute()
        {
            modbusClient = new ModbusClient("127.0.0.1", 502);
            // modbusClient = new ModbusClient("192.168.0.22", 1502);

            //modbusClient = new ModbusClient("192.168.200.18", 1502);
            modbusClient.ConnectedChanged += ModbusClient_ConnectedChanged;
            //processData.RequestModbusWriteEvent += requestModbusWriteEvent;
            processData.RequestModbusWrite = requestModbusWrite;

            List<int> requestResult = new List<int>();

            while (!cancelThread)
            {
                try
                {
                    if (modbusClient.Connected)
                    {
                        if (!requestToWrite.IsEmpty)
                        {
                            writeItems();
                            //ModbusWriteItem obj;
                            //requestToWrite.TryDequeue(out obj);
                            //if (obj.Distination == Distination.COIL)
                            //    modbusClient.WriteSingleCoil(obj.Addr, (bool)(obj.Val));
                            //else
                            //    modbusClient.WriteMultipleRegisters(obj.Addr, (int[])obj.Val);

                        }
                        else
                        {
                            processData.ModbusWriteCompleted = true;

                            processData.DTS = DateTime.Now;

                            if (processData.InputCount > 0)
                            {
                                requestResult.AddRange(modbusClient.ReadDiscreteInputs(0, processData.InputCount).ToIntList());
                                Thread.Sleep(50);
                            }
                            if (processData.CoilCount > 0)
                            {
                                if (processData.CoilCount <= 125)
                                    requestResult.AddRange(modbusClient.ReadCoils(0, processData.CoilCount).ToIntList());
                                else
                                {
                                    requestResult.AddRange(modbusClient.ReadCoils(0, 125).ToIntList());
                                    requestResult.AddRange(modbusClient.ReadCoils(125, processData.CoilCount - 125).ToIntList());
                                }
                                Thread.Sleep(50);
                            }
                            if (processData.InputRegisterCount > 0)
                            {
                                if (processData.InputRegisterCount <= 125)
                                    requestResult.AddRange(modbusClient.ReadInputRegisters(0, processData.InputRegisterCount).ToList());
                                else
                                {
                                    requestResult.AddRange(modbusClient.ReadInputRegisters(0, 125).ToList());
                                    requestResult.AddRange(modbusClient.ReadInputRegisters(125, processData.InputRegisterCount - 125).ToList());
                                }
                                Thread.Sleep(50);
                            }
                            if (processData.HoldigRegisterCount > 0)
                            {
                                if (processData.HoldigRegisterCount <= 120)
                                    requestResult.AddRange(modbusClient.ReadHoldingRegisters(0, processData.HoldigRegisterCount).ToList());
                                else
                                {
                                    requestResult.AddRange(modbusClient.ReadHoldingRegisters(0, 120).ToList());
                                    requestResult.AddRange(modbusClient.ReadHoldingRegisters(120, processData.HoldigRegisterCount - 120).ToList());
                                }
                                Thread.Sleep(50);
                            }
                        }

                    }
                    else
                        modbusClient.Connect();
                }

                catch (ConnectionException ex)
                {
                    logger.Error(ex, this.GetType().Name);
                    modbusClient.Disconnect();
                }

                catch (Exception ex)
                {

                    logger.Error(ex, this.GetType().Name);
                    modbusClient.Disconnect();
                }
                finally
                {
                    var modbusCounts = processData.InputCount + processData.CoilCount + processData.InputRegisterCount + processData.HoldigRegisterCount;
                    if (requestResult.Count != modbusCounts)
                    {
                        int i = requestResult.Count;
                        while (i < modbusCounts)
                        {
                            requestResult.Add(0);
                            i++;
                        }
                    }

                    processData.ExternalSet(requestResult.ToArray());

                    eventAggregator.GetEvent<ModbusMasterReadCompleted>().Publish();

                    requestResult.Clear();

                    Thread.Sleep(100);
                }
            }

            // exit 
            //processData.RequestModbusWriteEvent -= requestModbusWriteEvent;
            modbusClient.ConnectedChanged -= ModbusClient_ConnectedChanged;

            if (modbusClient.Connected)
                modbusClient.Disconnect();
        }

        private void writeItems()
        {
            foreach (var item in requestToWrite)
            {
                if (item.Distination == Distination.COIL)
                    modbusClient.WriteSingleCoil(item.Addr, (bool)(item.Val));
                else
                    modbusClient.WriteMultipleRegisters(item.Addr, (int[])item.Val);

                Thread.Sleep(50);
            }

            //ModbusWriteItem obj;

            //requestToWrite.TryDequeue(out obj);
            //if (obj.Distination == Distination.COIL)
            //    modbusClient.WriteSingleCoil(obj.Addr, (bool)(obj.Val));
            //else
            //    modbusClient.WriteMultipleRegisters(obj.Addr, (int[])obj.Val);
        }

        private void requestModbusWrite(ModbusWriteItem item)
        {
            requestToWrite.Enqueue(item);
        }

        //private void requestModbusWriteEvent(object sender, RequestModbusWriteEventArgs e)
        //{
        //    requestToWrite.Enqueue(e);
        //}
        private void ModbusClient_ConnectedChanged(object sender)
        {
            //eventAggregator.GetEvent<ModbusClientConnectedChangedEvent>().Publish((sender as ModbusClient).Connected ? 32 : 3);
            eventAggregator.GetEvent<ModbusMasterConnectedChangedEvent>().Publish((sender as ModbusClient).Connected ? true : false);

        }
    }

    public static class ArrayExtensions
    {
        public static List<int> ToIntList(this bool[] array)
        {
            List<int> result = new List<int>();
            foreach (var element in array)
            {
                result.Add(Convert.ToInt16(element));
            }
            return result;
        }
    }
}
