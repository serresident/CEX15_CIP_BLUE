using cip_blue.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace cip_blue.Models
{
    // для цветов
    //https://chir.ag/projects/name-that-color/#BF788B 
    public class ProcessDataTcp : ProcessData
    {
    
        #region inputs
       //mds dio 16bd ad=2      
        public bool SQH_V4101_voda{ get { return getValue<bool>(); } }// ad= 1 ch1
        public bool SQL_V4101_voda{ get { return getValue<bool>(); } }// ad=2 ch2
        public bool SQH_V4101_vozduh{ get { return getValue<bool>(); } }// ad=3 ch3
        public bool SQL_V4101_vozduh{ get { return getValue<bool>(); } }// ad=4 ch4
        public bool SQH_V4201_voda{ get { return getValue<bool>(); } }// ad=5 ch5
        public bool SQL_V4201_voda{ get { return getValue<bool>(); } }// ad=6 ch6
        public bool SQH_V4201_vozduh{ get { return getValue<bool>(); } }// ad=7 ch7
        public bool SQL_V4201_vozduh{ get { return getValue<bool>(); } }// ad=8 ch8
        public bool SQH_V4305_voda{ get { return getValue<bool>(); } }// ad=9 ch9
        public bool SQL_V4305_voda{ get { return getValue<bool>(); } }// ad=10 ch10
        public bool SQH_V160a_voda{ get { return getValue<bool>(); } }// ad=11 ch11
        public bool SQL_V160a_voda{ get { return getValue<bool>(); } }// ad=12 ch12
        public bool SQH_V4103_voda{ get { return getValue<bool>(); } }// ad=13 ch13
        public bool SQL_V4103_voda{ get { return getValue<bool>(); } }// ad=14 ch14
        public bool rezerv15{ get { return getValue<bool>(); } }// ad=15 ch15
        public bool rezerv16{ get { return getValue<bool>(); } }// ad=16 ch16
        public bool err_module_ad2{ get { return getValue<bool>(); } }
        public bool err_module_ad3{ get { return getValue<bool>(); } }
        public bool err_module_ad4{ get { return getValue<bool>(); } }
        public bool err_module_ad5{ get { return getValue<bool>(); } }
        public bool err_module_ad6{ get { return getValue<bool>(); } }
        public bool err_module_ad7 { get { return getValue<bool>(); } }
        public bool ttyS3_err_module_ad1 { get { return getValue<bool>(); } }
        public bool ttyS3_err_module_ad2 { get { return getValue<bool>(); } }
        public bool ttyS3_err_module_ad3 { get { return getValue<bool>(); } }
        public bool ttyS4_err_emis_mag270_ad1 { get { return getValue<bool>(); } }

        public bool valve1_pvs_SQH { get { return getValue<bool>(); } }
        public bool valve1_pvs_SQL { get { return getValue<bool>(); } }
        public bool valve2_pvs_SQH { get { return getValue<bool>(); } }
        public bool valve2_pvs_SQL { get { return getValue<bool>(); } }
        public bool valve3_pvs_SQH { get { return getValue<bool>(); } }
        public bool valve3_pvs_SQL { get { return getValue<bool>(); } }

        #endregion

        //Coils
        #region Coils
        public bool Logging{ get { return getValue<bool>(); } set { setValue<bool>(value); } }

        //line1_1  (ttyS2)       
        //mds dio 16bd ad=2      
        public bool out_V4101_voda { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad= 1 ch1
        public bool out_V4101_vozduh { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad=2 ch2
        public bool out_V4201_voda { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad=3 ch3
        public bool out_V4201_vozduh { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad=4 ch4
        public bool out_VB4305_voda { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad=5 ch5 в емкость 4305
        public bool out_V160a_voda { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad=6 ch6 в емкость 160а
        public bool out_VB4103_voda { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad=7 ch7 в емкость 4103
        public bool out_V160d_vozduh { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad=8 ch8 воздух на насос 160д
        public bool out_pusk_P4310b { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad=9 ch9  пуск насоса 4310б
        public bool out_stop_P4310b { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad=10 ch10 стоп насоса 4310б

        public bool rezerv11 { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad=11 ch11
        public bool rezerv12 { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad=12 ch12
        public bool rezerv13 { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad=13 ch13
        public bool rezerv14 { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad=14 ch14
        public bool rezerv15_1 { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad=15 ch15
        public bool rezerv16_1 { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad=16 ch16

        public bool Reset_WaterCount_4101 { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=17
        public bool Reset_WaterCount_4201 { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=18
        public bool Reset_WaterCount_160a { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=19

        public bool switch_promivka4101 { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=20
        public bool switch_promivka4201 { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=21
        public bool switch_ZagrVodi_160a { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=22
        public bool choice_rejim_4101 { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        public bool dop_uslovie_4101 { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        public bool dop_uslovie_4201 { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        public bool TV1_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } } //ad=54 
        public bool SW_Mixer { get { return getValue<bool>(); } set { setValue<bool>(value); } } //ad=54 

        public bool NS_B4305_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        public bool NS_B4305_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        public bool NS_B4305_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        public bool SW_FQ_auto_b4305 { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        public bool SW_water160a { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        public bool SW_Level_b4305 { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        public bool SW_Level_b4103 { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        public bool Valve1_pvs_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        public bool Valve1_pvs_man { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        public bool Valve1_pvs_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        public bool Valve1_pvs_out { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        public bool Valve2_pvs_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        public bool Valve2_pvs_man { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        public bool Valve2_pvs_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        public bool Valve2_pvs_out { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        public bool Valve3_pvs_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        public bool Valve3_pvs_man { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        public bool Valve3_pvs_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        public bool Valve3_pvs_out { get { return getValue<bool>(); } set { setValue<bool>(value); } }


        public bool err_deltacp2000 { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        public bool wait_pvs { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        public bool trig_4305 { get { return getValue<bool>(); }set { setValue<bool>(value); } }
public bool trig_4103 { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        public bool TV_P4310_open { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        public bool TV_P4310_close { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        public bool TV_P4310_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        public bool TV_P4310_man { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        public bool TV_P4310_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } }


        //ad=54 

        #endregion

        // Inputs Registers
        #region Inputs Registers


        //[ArchivAttribute("Вес мерника WE_D470")]
        //public Single WE_D470 { get { return getValue<Single>(); } }// ad= 1 _ch 1

        //line1_1       
        // mds8ui ad=5     
        public Single PIT_F4101_davlSuspenz{ get { return getValue<Single>(); } }// ad= 1 _ch 1 давление подаваемой суспензии +
        public Single TE2_F4101_tempSuspenz{ get { return getValue<Single>(); } }// ad= 3 _ch 2  температура подаваемой суспензии +
        public Single PIT2_F4101_davlGydroPrivoda{ get { return getValue<Single>(); } }// ad= 5 _ch 3  давление гидропривода
        public Single TE_F4101_tempVodi{ get { return getValue<Single>(); } }// ad= 7  _ch 4  температура воды подаваемой  на промывку
        public Single QIY_F4101_PhFiltrata{ get { return getValue<Single>(); } } //ad=9 _ch 5 ph фильтрата
        public Single PIT3_F4101_davlVodiPromiv{ get { return getValue<Single>(); } } //ad=11 _ch 6 давление воды на промывку
        public Single PIT4_F4101_davlVozduh{ get { return getValue<Single>(); } } //ad=13 _ch 7 давление воды на промывку
        public Single LE_B4103_urovenVodi{ get { return getValue<Single>(); } } //ad=15 _ch 8 Уровень в емкости промывных вод
                                   // mds8ui ad= 5     
        public Single LE_B4105_urovenKond{ get { return getValue<Single>(); } }// ad= 17 _ch 1 уровень в емкости конденсата
        public Single TT_B4305_tempKond{ get { return getValue<Single>(); } }// ad= 19 _ch 2  температура в емкости конденсата
        public Single TT_160a_tempRepulp{ get { return getValue<Single>(); } }// ad= 21 _ch 3  температура в апп. для репульпации
        public Single TT_B4103_tempEmkostiPromivVodi{ get { return getValue<Single>(); } }// ad= 23  _ch 4  температура в емкости промыв. вод
        public Single PIT_F4201_davlSuspenz{ get { return getValue<Single>(); } } //ad= 25 _ch 5 ph давление подаваемой суспензии

        public Single TE2_F4201_tempSuspenz{ get { return getValue<Single>(); } } //ad= 27 _ch 6 температура подаваемой суспензии
        public Single PIT2_F4201_davlGydroPrivoda{ get { return getValue<Single>(); } } //ad= 29 _ch 7 давление гидропривода
        public Single TE_F4201_tempVodi{ get { return getValue<Single>(); } } //ad= 31 _ch 8 Уровень в емкости промывных вод

        // mds8ui ad= 6     
        public Single QIY_F4201_electrFiltrata{ get { return getValue<Single>(); } }// ad= 33 _ch 1  электропроводность фильтрата
        public Single PIT3_F4201_davlVodi{ get { return getValue<Single>(); } }// ad= 35 _ch 2  давление воды на промывку
        public Single PIT4_F4201_davlVozduha{ get { return getValue<Single>(); } }// ad= 37 _ch 3  давление воздуха

        public Single ch4{ get { return getValue<Single>(); } }// ad= 39  _ch 4 
        public Single ch5{ get { return getValue<Single>(); } } //ad= 41 _ch 5 p
        public Single ch6{ get { return getValue<Single>(); } } //ad= 43 _ch 6
        public Single ch7{ get { return getValue<Single>(); } } //ad= 45 _ch 7 
        public Single ch8{ get { return getValue<Single>(); } } //ad= 47 _ch 8 
        public Single WaterCount_4201 { get { return getValue<Single>(); } }//ad=49
        public Single WaterCount_4101 { get { return getValue<Single>(); } }//ad=51
        public Single WaterCount_160a { get { return getValue<Single>(); } }//ad=53
        public UInt32 WaterCount_4201_32 { get { return getValue<UInt32>(); } }//ad=55
        public UInt32 WaterCount_4101_32 { get { return getValue<UInt32>(); } }//ad=57
        public UInt32 WaterCount_160a_32 { get { return getValue<UInt32>(); } }//ad=59

        public UInt16 WaterCount_4201_16 { get { return getValue<UInt16>(); } }//ad=61
        public UInt16 WaterCount_4101_16 { get { return getValue<UInt16>(); } }//ad=62
        public UInt16 WaterCount_160a_16 { get { return getValue<UInt16>(); } }//ad=63
        public UInt16 empty1 { get { return getValue<UInt16>(); } } //ad=64
        public Single Fakt_Vodi_160a { get { return getValue<Single>(); } }//ad=65
        public UInt16 Load_water_160a_status { get { return getValue<UInt16>(); } } //ad=67
        public UInt16 JOURNAL2 { get { return getValue<UInt16>(); } }  //ad=68

        public Single cip4101_status{ get { return getValue<Single>(); } } //ad=
        public Single cip4101_time { get { return getValue<Single>(); } } //ad=

        public Single cip4201_status { get { return getValue<Single>(); } } //ad=
        public Single cip4201_time { get { return getValue<Single>(); } } //ad=
         public Single PE1{ get { return getValue<Single>(); } }  //ad=
         public Single PE3{ get { return getValue<Single>(); } }  //ad=
         public Single PE2{ get { return getValue<Single>(); } }  //ad=
         public Single TE1{ get { return getValue<Single>(); } }  //ad=
         public Single TE3{ get { return getValue<Single>(); } }  //ad=
         public Single TE2{ get { return getValue<Single>(); } }  //ad=

        public Single LE_B4305 { get { return getValue<Single>(); } }  //ad=
        public Single FQ_B4305 { get { return getValue<Single>(); } }  //ad=
        public Single FQ_B4305_counter { get { return getValue<Single>(); } }  //ad=
        public Single NS4305_frq { get { return getValue<Single>(); } }
        public Single NS4305_Amperage { get { return getValue<Single>(); } }
        public UInt16 NS4305_delta_status { get { return getValue<UInt16>(); } }
        public UInt16 empty33 { get { return getValue<UInt16>(); } }

        public Single time_left_load_160a { get { return getValue<Single>(); } }

        

        public UInt16 JOURNAL = 0;//  заглушка проверки , убирает защиту от записи в бд при обрыви связи с плк
        public bool testOn = false;//  заглушка проверки , убирает защиту от записи в бд при обрыви связи с плк
                                   //ad108  должен быть последним ,служит для определения успешного чтения регистров
                                   //ad=82 


        #endregion

        // Holdings Registers
        #region Holdings Registers
        //******************line1_1 ********************      
        //mu 110 8i ad=5       
        //    public UInt16 NC_P412_aout { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }  // ad= 1 _ch 1 
        //mu 110 8i ad=5        //mu 110 8i ad=5        //mu 110 8i ad=5       	//mu 110 8i ad=5       
        [Settings]
        [Category("PID регулятор шнека")]
        [DisplayName("Kp")]
        [Description("Пропорц. коэф.")]
        [PropertyOrder(2, UsageContextEnum.Categorized)]
        public Single time_delay { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad1
        public Single time_imp { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad3
        public Single Doza_Vodi_160a { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad5
        public Single predvaritel_zakr_160a { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad5

          public Single sp_vremya_promivki_4101_n0 { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad7
          public Single sp_vremya_pauzi1_4101_n0{ get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad9
          public Single sp_vremya_vozduha_4101_n0 { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad11
          public Single sp_vremya_pauzi2_4101_n0 { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad13
          public Single sp_vremya_produvki_4101_n0 { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad15

          public Single sp_qe_4101_n0{ get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad17
          public Single sp_Fq_4101_n0{ get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad19


          public Single sp_qe_4201{ get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad21
          public Single sp_Fq_4201{ get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad23

          public Single sp_qe_4101_n2 { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad25
          public Single sp_Fq_4101_n2 { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad27

          public Single sp_vremya_promivki_4101_n2 { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad29
          public Single sp_vremya_pauzi1_4101_n2 { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad31
          public Single sp_vremya_vozduha_4101_n2 { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad33
          public Single sp_vremya_pauzi2_4101_n2 { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad35
          public Single sp_vremya_produvki_4101_n2 { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad37

          public Single sp_vremya_promivki_4201_n1 { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad7
          public Single sp_vremya_pauzi1_4201_n1 { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad9
          public Single sp_vremya_vozduha_4201_n1 { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad11
          public Single sp_vremya_pauzi2_4201_n1 { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad13
          public Single sp_vremya_produvki_4201_n1{ get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad15

          public Single sp_vremya_promivki_4101_n1 { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad7
          public Single sp_vremya_pauzi1_4101_n1 { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad9
          public Single sp_vremya_vozduha_4101_n1 { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad11
          public Single sp_vremya_pauzi2_4101_n1 { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad13
          public Single sp_vremya_produvki_4101_n1{ get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad15
          public Single sp_qe_4101_n1{ get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad17
          public Single sp_Fq_4101_n1 { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad19

        public Single Tzad_pvs{ get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad
        public Single KP_pvs{ get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad
        public Single TN_pvs{ get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad
        public Single TV_pvs{ get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad

        public Single TV1_Control_auto{ get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad// 
        public Single TV1_Control_man{ get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad  
        public Single TV1_Aout{ get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad

        public Single NSB4305_Control_auto_frq { get { return getValue<Single>(); } set { setValue<Single>(value); } }// 
        public Single NSB4305_Control_man_frq { get { return getValue<Single>(); } set { setValue<Single>(value); } } //          
        public Single NSB4305_Control_out_frq { get { return getValue<Single>(); } set { setValue<Single>(value); } } // 


        public Single Fq_zad_b4305 { get { return getValue<Single>(); } set { setValue<Single>(value); } } // 
        public Single KP_b4305 { get { return getValue<Single>(); } set { setValue<Single>(value); } } // 
        public Single TN_b4305 { get { return getValue<Single>(); } set { setValue<Single>(value); } } // 
        public Single TV_b4305 { get { return getValue<Single>(); } set { setValue<Single>(value); } } // 

        public Single set_level_high_b4103 { get { return getValue<Single>(); } set { setValue<Single>(value); } } // 
        public Single set_level_low_b4103 { get { return getValue<Single>(); } set { setValue<Single>(value); } } // 
        public Single set_level_high_b4305 { get { return getValue<Single>(); } set { setValue<Single>(value); } } // 
        public Single set_level_low_b4305 { get { return getValue<Single>(); } set { setValue<Single>(value); } } // 
        public Single T_zagr_160b { get { return getValue<Single>(); } set { setValue<Single>(value); } } // 
        public Single T_zagr_4305b { get { return getValue<Single>(); } set { setValue<Single>(value); } } // 
        public Single T_zagr_4103b { get { return getValue<Single>(); } set { setValue<Single>(value); } } // 
        #endregion
    }

}
