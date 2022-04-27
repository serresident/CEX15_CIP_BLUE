using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using cip_blue.Attributes;
using cip_blue.Helpers;
using cip_blue.Models;
using cip_blue.Repositories;

namespace cip_blue.ViewModels
{
	public class JournalViewModel : BindableBase
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000072 RID: 114 RVA: 0x000038A4 File Offset: 0x00001AA4
		// (set) Token: 0x06000073 RID: 115 RVA: 0x000038BC File Offset: 0x00001ABC
		public ObservableRangeCollection<JournalItem> JournalItems
		{
			get
			{
				return this.journalItems;
			}
			set
			{
				this.SetProperty<ObservableRangeCollection<JournalItem>>(ref this.journalItems, value, "JournalItems");
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000074 RID: 116 RVA: 0x000038D4 File Offset: 0x00001AD4
		// (set) Token: 0x06000075 RID: 117 RVA: 0x000038EC File Offset: 0x00001AEC
		public ProcessDataTcp PD
		{
			get
			{
				return this._pd;
			}
			set
			{
				this.SetProperty<ProcessDataTcp>(ref this._pd, value, "PD");
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000076 RID: 118 RVA: 0x00003904 File Offset: 0x00001B04
		// (set) Token: 0x06000077 RID: 119 RVA: 0x0000391C File Offset: 0x00001B1C
		public bool IsBusy
		{
			get
			{
				return this.isBusy;
			}
			set
			{
				this.SetProperty<bool>(ref this.isBusy, value, "IsBusy");
			}
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00003932 File Offset: 0x00001B32
		public JournalViewModel(ProcessDataTcp pd, JournalRepository journalRepository)
		{
			this.PD = pd;
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00003944 File Offset: 0x00001B44
		public void OnLoading()
		{
			Task.Factory.StartNew(delegate ()
			{
				this.IsBusy = true;
				List<JournalItem> _journalItems = new List<JournalItem>();
				foreach (PropertyInfo prop in from p in this.PD.GetType().GetProperties()
											  where p.PropertyType.IsPrimitive && Attribute.IsDefined(p, typeof(JournalAttribute))
											  select p)
				{
					JournalAttribute[] attr = (JournalAttribute[])prop.GetCustomAttributes(typeof(JournalAttribute), false);
					string message = attr[0].Message.Substring(0, attr[0].Message.IndexOf(">") - 1);
					_journalItems.Add(new JournalItem
					{
						Message = message,
						Property = prop.Name
					});
				}
				this.JournalItems = new ObservableRangeCollection<JournalItem>(_journalItems);
			}).ContinueWith(delegate (Task x)
			{
				this.IsBusy = false;
			}, TaskScheduler.FromCurrentSynchronizationContext());
		}

		// Token: 0x04000038 RID: 56
		private ObservableRangeCollection<JournalItem> journalItems;

		// Token: 0x04000039 RID: 57
		private ProcessDataTcp _pd;

		// Token: 0x0400003A RID: 58
		private bool isBusy;
	}
}