using cip_blue.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cip_blue.Models
{
    // для цветов
    //https://chir.ag/projects/name-that-color/#BF788B 
    public class ProcessDataTcp : ProcessData
    {
        // InputsV_K480B_1_mode
        #region inputs
        //line1_1           
        //owen mv16 dn ad 1        
        //line1_1           
        //owen mv16 dn ad 1        
        public bool NC_610M_Sost { get { return getValue<bool>(); } }// ad= 1 mv16 dn ad 1 line1_1 _ch 1
        public bool NS_VodaArt_Sost { get { return getValue<bool>(); } }// ad= 2 mv16 dn ad 1 line1_1 _ch 2
        public bool NS_VodaGor_Sost { get { return getValue<bool>(); } }// ad= 3 mv16 dn ad 1 line1_1 _ch 3
        public bool Pmin_P461 { get { return getValue<bool>(); } }// ad= 4 mv16 dn ad 1 line1_1 _ch 4
        public bool NS_631A_M_Sost { get { return getValue<bool>(); } }// ad= 5 mv16 dn ad 1 line1_1 _ch 5

        public bool FV_K450A_SQH { get { return getValue<bool>(); } }// ad= 6 mv16 dn ad 1 line1_1 _ch 6
        public bool FV_K450A_SQL { get { return getValue<bool>(); } }// ad= 7 mv16 dn ad 1 line1_1 _ch 7

        public bool V_K610_SQH { get { return getValue<bool>(); } }// ad= 8 mv16 dn ad 1 line1_1 _ch 8
        public bool V_K610_SQL { get { return getValue<bool>(); } }// ad= 9 mv16 dn ad 1 line1_1 _ch 9
                                                                   //line2_1        
                                                                   // owen 16dn ad1        
        public bool VK480B_7_SQH { get { return getValue<bool>(); } }// ad= 10 mv110_16dn_1 _ch 1
        public bool VK480B_7_SQL { get { return getValue<bool>(); } }// ad= 11 mv110_16dn_1 _ch 2

        public bool WVR404A_SQH { get { return getValue<bool>(); } }// ad= 12 mv110_16dn_1 _ch 3
        public bool WVR404A_SQL { get { return getValue<bool>(); } }// ad= 13 mv110_16dn_1 _ch
        public bool VD460A_SQH { get { return getValue<bool>(); } }// ad= 14 mv110_16dn_1 _ch 5
        public bool VD460A_SQL { get { return getValue<bool>(); } }// ad= 15 mv110_16dn_1 _ch 6

        public bool NS_P611_sost { get { return getValue<bool>(); } }// ad= 16 mv110_16dn_1 _ch 7
        public bool NS_K480B_sost { get { return getValue<bool>(); } }// ad= 17 mv110_16dn_1 _ch 8
        public bool NS_K480A_sost { get { return getValue<bool>(); } }// ad= 18 mv110_16dn_1 _ch 9
        public bool NS_P402_sost { get { return getValue<bool>(); } }// ad= 19 mv110_16dn_1 _ch 10
        public bool NS_P201C_sost { get { return getValue<bool>(); } }// ad= 20 mv110_16dn_1 _ch 11
        public bool NS_P404A_sost { get { return getValue<bool>(); } }// ad= 21 mv110_16dn_1 _ch 12
        public bool NS_K460A_sost { get { return getValue<bool>(); } }// ad= 22 mv110_16dn_1 _ch 13
        public bool NS_K460B_sost { get { return getValue<bool>(); } }// ad= 23 mv110_16dn_1 _ch 14
                                                                      // mv110_16dn_6->Read(){ get { return getValue<bool>(); } }        
        public bool TV_K450A_SQH { get { return getValue<bool>(); } }// ad= 24 mv110_16dn_6 _ch 3
        public bool TV_K450A_SQL { get { return getValue<bool>(); } }// ad= 25 mv110_16dn_6 _ch 4

        public bool V_K450A_SQH { get { return getValue<bool>(); } }// ad= 26 mv110_16dn_6 _ch 5
        public bool V_K450A_SQL { get { return getValue<bool>(); } }// ad= 27 mv110_16dn_6 _ch 6

        public bool pHV_K450A_SQH { get { return getValue<bool>(); } }// ad= 28 mv110_16dn_6 _ch 9
        public bool pHV_K450A_SQL { get { return getValue<bool>(); } }// ad= 29 mv110_16dn_6 _ch 10

        public bool V_K480A_8_SQH { get { return getValue<bool>(); } }// ad= 30 mv110_16dn_6 _ch 11
        public bool V_K480A_8_SQL { get { return getValue<bool>(); } }// ad= 31 mv110_16dn_6 _ch 12

        public bool V_K480B_8_SQH { get { return getValue<bool>(); } }// ad= 32 mv110_16dn_6 _ch 13
        public bool V_K480B_8_SQL { get { return getValue<bool>(); } }// ad= 33 mv110_16dn_6 _ch 14

        public bool V_K480A_9_SQH { get { return getValue<bool>(); } }// ad= 34 mv110_16dn_6 _ch 15
        public bool V_K480A_9_SQL { get { return getValue<bool>(); } }// ad= 35 mv110_16dn_6 _ch 16
                                                                      //mv110_16dn_7->Read(){ get { return getValue<bool>(); } }        
        public bool V_K480B_9_SQH { get { return getValue<bool>(); } }// ad= 36 mv110_16dn_7 _ch 1
        public bool V_K480B_9_SQL { get { return getValue<bool>(); } }// ad= 37 mv110_16dn_7 _ch 2

        public bool V_K480A_11_SQH { get { return getValue<bool>(); } }// ad= 38 mv110_16dn_7 _ch 3
        public bool V_K480A_11_SQL { get { return getValue<bool>(); } }// ad= 39 mv110_16dn_7 _ch 4

        public bool V_K480B_11_SQH { get { return getValue<bool>(); } }// ad= 40 mv110_16dn_7 _ch 5
        public bool V_K480B_11_SQL { get { return getValue<bool>(); } }// ad= 41 mv110_16dn_7 _ch 6

        public bool V_K480A_10_SQH { get { return getValue<bool>(); } }// ad= 42 mv110_16dn_7 _ch 7
        public bool V_K480A_10_SQL { get { return getValue<bool>(); } }// ad= 43 mv110_16dn_7 _ch 8

        public bool V_K480B_10_SQH { get { return getValue<bool>(); } }// ad= 44 mv110_16dn_7 _ch 9
        public bool V_K480B_10_SQL { get { return getValue<bool>(); } }// ad= 45 mv110_16dn_7 _ch 10

        public bool V_E461A_1_SQH { get { return getValue<bool>(); } }// ad= 46 mv110_16dn_7 _ch 11
        public bool V_E461A_1_SQL { get { return getValue<bool>(); } }// ad= 47 mv110_16dn_7 _ch 12

        public bool V_E461A_2_SQH { get { return getValue<bool>(); } }// ad= 48 mv110_16dn_7 _ch 13
        public bool V_E461A_2_SQL { get { return getValue<bool>(); } }// ad= 49 mv110_16dn_7 _ch 14

        public bool V_E461A_SQH { get { return getValue<bool>(); } }// ad= 50 mv110_16dn_7 _ch 15
        public bool V_E461A_SQL { get { return getValue<bool>(); } }// ad= 51 mv110_16dn_7 _ch 16
                                                                    //mv110_16dn_8->Read(){ get { return getValue<bool>(); } }        
        public bool NC_K450A_sost { get { return getValue<bool>(); } }// ad= 52 mv110_16dn_8 _ch 8
        public bool NC_K450A_alarm { get { return getValue<bool>(); } }// ad= 53 mv110_16dn_8 _ch 9

        // plc1 
        public bool FV_R631A_SQH { get { return getValue<bool>(); } } // ad=54  di1
        public bool FV_R631A_SQL { get { return getValue<bool>(); } } // ad=55  di2
        public bool FV_R603_SQH { get { return getValue<bool>(); } } // ad=56 di3 yes
        public bool FV_R603_SQL { get { return getValue<bool>(); } } // ad=57 di4
        public bool FV_R521_SQH { get { return getValue<bool>(); }
} // ad=58 di5
public bool FV_R521_SQL { get { return getValue<bool>(); } } // ad=59 di6
public bool LV_R422_SQH { get { return getValue<bool>(); } } //ad=60 di7 yes
public bool LV_R422_SQL { get { return getValue<bool>(); } } //ad=61 di8 ??

public bool TV_K610_SQH { get { return getValue<bool>(); } }// ad=62 di9  ??
public bool TV_K610_SQL { get { return getValue<bool>(); } } // ad=63 di10   yes
public bool FV_K480A_SQH { get { return getValue<bool>(); } } // ad=64 di11
public bool FV_K480A_SQL { get { return getValue<bool>(); } } // ad=65 di12
public bool FV_K480B_SQH { get { return getValue<bool>(); } } // ad=66 di13
public bool FV_K480B_SQL { get { return getValue<bool>(); } } // ad=67 di14
public bool FV_K460A_SQH { get { return getValue<bool>(); } } // ad=68 di15
public bool FV_K460A_SQL { get { return getValue<bool>(); } } // ad=69 di16

public bool FV_K460B_SQH { get { return getValue<bool>(); } } // ad=70 di17
public bool FV_K460B_SQL { get { return getValue<bool>(); } } // ad=71 di18
public bool FV_K460C_SQH { get { return getValue<bool>(); } } // ad=72 di13
public bool FV_K460C_SQL { get { return getValue<bool>(); } } // ad=73 di20
public bool FV_R471_SQH { get { return getValue<bool>(); } } // ad=74 di21
public bool FV_R471_SQL { get { return getValue<bool>(); } } // ad=75 di22
public bool NS_P470_sost { get { return getValue<bool>(); } } // ad=76 di23
public bool NS_603M_sost { get { return getValue<bool>(); } } // ad=77 di24

public bool NS_521M_sost  { get { return getValue<bool>(); } } // ad=78 di25
public bool NS_P603_sost { get { return getValue<bool>(); } } // ad=79 di26
public bool NS_P521_sost { get { return getValue<bool>(); } } // ad=80 di27
public bool NS_P631A_sost { get { return getValue<bool>(); } } // ad=81 di28
public bool NS_422M_sost { get { return getValue<bool>(); } } // ad=82 di29
public bool NS_P461_sost { get { return getValue<bool>(); } } // ad=83 di30
public bool NS_LXU_sost { get { return getValue<bool>(); } } // ad=84 di31 
public bool NC_P412_sost { get { return getValue<bool>(); } } // ad=85 di32

//plc2*************************
public bool VK480A_1_SQH { get { return getValue<bool>(); } } //ad=86 di1  ?? инверсия
public bool VK480A_1_SQL { get { return getValue<bool>(); } } //ad=87 di2  ??
public bool VK480B_1_SQH { get { return getValue<bool>(); } } //ad=88 di3 ??
public bool VK480B_1_SQL { get { return getValue<bool>(); } } //ad=89 di4 yes

public bool VK480A_2_SQH { get { return getValue<bool>(); } } //ad=90 di5 ?? не работает
public bool VK480A_2_SQL { get { return getValue<bool>(); } } //ad=91 di6 yes
public bool VK480B_2_SQH { get { return getValue<bool>(); } } //ad=92 di7 ?? не работает
public bool VK480B_2_SQL { get { return getValue<bool>(); } } //ad=93 di8 yes

public bool TVK480A_SQH { get { return getValue<bool>(); } } //ad=94 di9  ??
public bool TVK480A_SQL { get { return getValue<bool>(); } } //ad=95 di10  no
public bool TVK480B_SQH { get { return getValue<bool>(); } } //ad=96 di11   ??
public bool TVK480B_SQL { get { return getValue<bool>(); } } //ad=97 di12 no

public bool VK480A_3_SQH { get { return getValue<bool>(); } } //ad=98 di13   инверсия с sql ?
public bool VK480A_3_SQL { get { return getValue<bool>(); } } //ad=99 di14   ??
public bool VK480B_3_SQH { get { return getValue<bool>(); } } //ad=100 di15  ??
public bool VK480B_3_SQL { get { return getValue<bool>(); } } //ad=101 di16   yes

public bool VK480A_4_SQH { get { return getValue<bool>(); } } //ad=102 di17  ??
public bool VK480A_4_SQL { get { return getValue<bool>(); } } //ad=103 di18  yes
public bool VK480B_4_SQH { get { return getValue<bool>(); } } //ad=104 di19  ??
public bool VK480B_4_SQL { get { return getValue<bool>(); } } //ad=105 di20 yes

public bool VK480A_5_SQH { get { return getValue<bool>(); } } //ad=106 di21 ??    //проверить
public bool VK480A_5_SQL { get { return getValue<bool>(); } } //ad=107 di22  no
public bool VK480B_5_SQH { get { return getValue<bool>(); } } //ad=108 di23  ??
public bool VK480B_5_SQL { get { return getValue<bool>(); } } //ad=109 di24  no

public bool VK480A_6_SQH { get { return getValue<bool>(); } } //ad=110 di25  ??
public bool VK480A_6_SQL { get { return getValue<bool>(); } } //ad=111 di26  yes
public bool VK480B_6_SQH { get { return getValue<bool>(); } } //ad=112 di27  ??
public bool VK480B_6_SQL { get { return getValue<bool>(); } } //ad=113 di28  yes
public bool VK480A7_SQH { get { return getValue<bool>(); } } //ad=114 di29  ??
public bool VK480A7_SQL { get { return getValue<bool>(); } } //ad=115 di30  yes

public bool delta_p726_status { get { return getValue<bool>(); } } //ad=116
public bool NC_K480B_Dstatus { get { return getValue<bool>(); } } //ad=117





#endregion

//Coils
#region Coils


//line1_1  (ttyS2)       
//owen mv110 16r ad=2      
public bool NS_VodaArt_pusk { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad= 1 line1_1 owen mv110 16r ad=2 _ch 1
        public bool NS_VodaArt_stop { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad= 2 line1_1 owen mv110 16r ad=2 _ch 2
        public bool NS_VodaGor_pusk { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad= 3 line1_1 owen mv110 16r ad=2 _ch 3
        public bool NS_VodaGor_stop { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad= 4 line1_1 owen mv110 16r ad=2 _ch 4
        public bool valve_PromivkaPH_610 { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad= 5 line1_1 owen mv110 16r ad=2 _ch 5
        public bool valve_PromivkaPH_450A { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad= 6 line1_1 owen mv110 16r ad=2 _ch 6

        //line2_1  (ttyS4)       
        // mu 110 16r ad=9       
        public bool TV_K450A_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad= 7  line2_2 mu 110 16r ad=9  _ch 1
        public bool V_K450A_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad= 8  line2_2 mu 110 16r ad=9  _ch 2
        public bool promiv_ph_K480a { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad= 9  line2_2 mu 110 16r ad=9  _ch 3
        public bool V_E461A_1_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad= 10  line2_2 mu 110 16r ad=9  _ch 4
        public bool V_E461A_2_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad= 11  line2_2 mu 110 16r ad=9  _ch 5
        public bool V_E461A_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad= 12  line2_2 mu 110 16r ad=9  _ch 6
        public bool NC_K450A_pusk { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad= 13  line2_2 mu 110 16r ad=9  _ch 7
        public bool NC_K450A_stop { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad= 14  line2_2 mu 110 16r ad=9  _ch 8

        // HMI
        public bool NS_P470_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=15 // нас
        public bool NS_P470_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=16
        public bool NS_P470_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=17

        public bool Logging { get { return getValue<bool>(); } set { setValue<bool>(value); } } //ad 18

public bool Pmin_P461_Duplicate { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad 19

public bool FV_R631A_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } } //ad=20 do1
public bool FV_R603_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 21  do 2
public bool FV_R521_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 22  do 3
public bool LV_R422_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 23  do 4
public bool TV_K610_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 24  do 5
public bool FV_K480A_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 25  do 6
public bool FV_K480B_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 26  do 7
public bool FV_K460A_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 27  do 8
public bool FV_K460B_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 28  do 9
public bool FV_K460C_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 29  do 10
public bool FV_R471_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 30  do 11
public bool FV_K450A_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 31  do 12
public bool V_K610_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 32  do 13
public bool empty { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 33  do 14
public bool NS_P470_pusk { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 34  do 15
public bool NS_P470_stop { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 35  do 16
public bool NS_P603_stop { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 36  do 17
public bool NS_P521_stop { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 37  do 18
public bool NS_P631A_stop { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 38  do 19
public bool NS_P461_stop { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 39  do 20
public bool NC_P412_pusk { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 40  do 21
public bool NC_P412_stop { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 41  do 22
public bool NC_610M_pusk { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 42  do 23
public bool NC_610M_stop { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 43  do 24

//********************** Dvigateli
public bool NS_P603_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=44  Управление насосом соды P603
public bool NS_P521_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } //ad=45   Управление насосом соды P521
public bool NS_P631A_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } //ad=46   Управление насосом соды P631A
public bool NS_P461_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } //ad=47   Управление насосом соды P461

public bool NS_VodaArt_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad=48 управление насосом арт воды
public bool NS_VodaArt_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=49 авт
public bool NS_VodaArt_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } //ad=50 ручн 

public bool NS_VodaGor_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } } //ad=51  управление насосом гор воды
public bool NS_VodaGor_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad=52
public bool NS_VodaGor_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=53

public bool NC_M610_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } } //ad=54 управ меш реактора
public bool NC_M610_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad=55
public bool NC_M610_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=56

public bool NC_P412_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } } //ad=57 управ меш реактора
public bool NC_P412_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad=58
public bool NC_P412_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=59

//***************************KLAPAN*******************

public bool FV_R631A_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=60
public bool FV_R631A_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=61
public bool FV_R631A_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=62

public bool FV_R603_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=63
public bool FV_R603_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=64
public bool FV_R603_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=65

public bool FV_R521_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=66
public bool FV_R521_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=67
public bool FV_R521_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=68

public bool LV_R422_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=69
public bool LV_R422_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=70
public bool LV_R422_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=71

public bool TV_K610_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=72
public bool TV_K610_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=73
public bool TV_K610_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=74

public bool FV_K480A_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=75
public bool FV_K480A_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=76
public bool FV_K480A_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=77

public bool FV_K480B_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=78
public bool FV_K480B_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=79
public bool FV_K480B_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=80

public bool FV_K460A_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=81
public bool FV_K460A_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=82
public bool FV_K460A_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=83

public bool FV_K460B_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=84
public bool FV_K460B_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=85
public bool FV_K460B_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=86

public bool FV_K460C_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=87
public bool FV_K460C_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=88
public bool FV_K460C_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=89

public bool FV_R471_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=90
public bool FV_R471_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=91
public bool FV_R471_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=92

public bool FV_K450A_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=93
public bool FV_K450A_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=94
public bool FV_K450A_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=95

public bool V_K610_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=96///////////////////
public bool V_K610_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=97
public bool V_K610_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=98

public bool FV_K480B_reg_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad=99/////////////////////
public bool FV_K480A_reg_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=100

 [JournalAttribute("Загрузка арт. воды изменение состояние на СТАРТ >> [{0}] --> [{1}]")]
public bool ZagrVodaComm_Start { get { return getValue<bool>(); } set { setValue<bool>(value); } } //ad=101

[JournalAttribute("VK480A_2 изменение режима >> [{0}] --> [{1}]")]
public bool VK480A_2_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=102
public bool VK480A_2_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } } //ad= 103
public bool VK480A_2_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 104

//plc2 dout***************
public bool NS_P402_stop { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=105 dof1
public bool NS_P201C_stop { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=106 dof2
public bool NS_P404A_stop { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=107 dof3
public bool VK480A_1_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=108 dof4

public bool VK480B_1_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=109 do1
public bool VK480A_2_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=110 do2
public bool VK480B_2_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=111 do3
public bool TVK480A_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=112 do4
public bool TVK480B_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=113 do5
public bool VK480A_3_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=114 do6
public bool VK480B_3_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=115 do7
public bool VK480A_4_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=116 do8

public bool VK480B_4_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=117 do9
public bool VK480A_5_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=118 do8
public bool VK480B_5_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=119 do10
public bool VK480A_6_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=120 do11
public bool VK480B_6_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=121 do12
public bool WVR404A_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=122 do13
public bool VD460A_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=123 do14
public bool empty_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=124 do15

public bool VK480B_2_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=125 
public bool VK480B_2_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=126
public bool VK480B_2_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=127

// выход оборотной рубашки
public bool VK480A_3_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=128
public bool VK480A_3_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=129
public bool VK480A_3_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=130

public bool VK480B_3_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=131
public bool VK480B_3_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=132
public bool VK480B_3_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=133

// (*выход  воды после продувки *)
public bool VK480A_4_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=134
public bool VK480A_4_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=135
public bool VK480A_4_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=136

public bool VK480B_4_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=137
public bool VK480B_4_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=138
public bool VK480B_4_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=139
//(*подача оборотной воды в рубашку*)
public bool VK480A_5_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=140
public bool VK480A_5_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=141
public bool VK480A_5_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=142

public bool VK480B_5_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=143
public bool VK480B_5_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=144
public bool VK480B_5_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } }//a=145
// (*подача воздуха на продувку рубашки*)
public bool VK480A_6_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=146
public bool VK480A_6_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=147
public bool VK480A_6_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=148

public bool VK480B_6_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=149
public bool VK480B_6_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=150
public bool VK480B_6_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=151

public bool WVR404A_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=152
public bool WVR404A_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=153
public bool WVR404A_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=154

public bool VD460A_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=155
public bool VD460A_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=156
public bool VD460A_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=157

public bool V_K450A_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=158
public bool V_K450A_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=159
public bool V_K450A_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=160

public bool V_E461A_1_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=161
public bool V_E461A_1_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=162
public bool V_E461A_1_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=163

public bool V_E461A_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=164
public bool V_E461A_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=165
public bool V_E461A_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=166

public bool TV_K450A_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=167
public bool TV_K450A_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=168
public bool TV_K450A_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=169

public bool V_E461A_2_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=170
public bool V_E461A_2_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=171
public bool V_E461A_2_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=172

public bool VK480A_7_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=173
public bool VK480B_7_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=174
public bool VK480A_1_reg_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=175
public bool VK480B_1_reg_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=176
public bool pHV_K450A_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=177
public bool V_K480A_8_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=178
public bool V_K480B_8_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=179
public bool V_K480A_9_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=180
public bool V_K480B_9_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=181
public bool V_K480A_10_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=182
public bool V_K480B_10_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=183
public bool V_K480A_11_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=184
public bool V_K480B_11_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=185

public bool NC_K450A_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } } //ad=186 управ меш реактора
public bool NC_K450A_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad=187
public bool NC_K450A_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=188

public bool TVK480A_mode{ get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=189
public bool TVK480A_man_dout{ get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=190

public bool TVK480B_mode{ get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=191
public bool TVK480B_man_dout{ get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=192

public bool ZagrKond460Comm_Start{ get { return getValue<bool>(); } set { setValue<bool>(value); } } //ad=193
public bool ZagrKond480Comm_Start{ get { return getValue<bool>(); } set { setValue<bool>(value); } } //ad=194

        // from r422
public bool fromR422_xStart{ get { return getValue<bool>(); } set { setValue<bool>(value); } } //ad=195
public bool fromR422_xOk { get { return getValue<bool>(); } set { setValue<bool>(value); } }  //ad=196
public bool fromR422_xEndZagr2 { get { return getValue<bool>(); } set { setValue<bool>(value); } } //ad=197
                                                                                                   //охлаждение к480A/B
public bool Ohlagd480_Start { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=198

public bool P726_Access_Wr_Frq { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=199
public bool P726_Auto { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=200

public bool RegPH480A_Start { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=201
public bool NC_K480B_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=202

public bool NC_K480B_Access_Wr_Frq { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=203

public bool ZagrMorfolinK480_Start { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=204
public bool ZagrMorfolinK480_IsEnablePredictClose { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad205
public bool RegPH480B_Start { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=206

public  bool Res_fq521 { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad207
public bool Res_fq460 { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad208
public bool Res_fq480{ get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad209

public bool testing{ get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad210

public bool ZagrDietilK480_Start{ get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=211
public bool ZagrDietilK480_IsEnablePredictClose{ get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad212
public bool NC_K480A_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=213
public bool ZagrDietilAminK480_Start { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=214
public bool ZagrDietilAminK480_IsEnablePredictClose { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad215

        public bool Intercept_plc1 { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad216
        public bool Intercept_plc2 { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad217

        public bool pHV_K610_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=218

        public bool ResetCount_FV521 { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=219
        public bool ResetCount_FV460 { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=220
        public bool ResetCount_FV480 { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=221
        public bool ZagrAnilin480_Start { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad222
        public bool ZagrAnilin480_IsEnablePredictClose { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad223
        public bool PID_ON_Tperegon_A { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad224
        public bool start_LoadWater_perA { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad225
        public bool pause_LoadWater_perA { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad226
        #endregion

        // Inputs Registers
        #region Inputs Registers

        //line1_1       
        //owen mv 8as ad=3
        [ArchivAttribute("Вес мерника WE_D470")]
        public Single WE_D470 { get { return getValue<Single>(); } }// ad= 1 _ch 1
        [ArchivAttribute("уровень LT_R137")]
        public Single LT_R137 { get { return getValue<Single>(); } }// ad= 3 _ch 2
        [ArchivAttribute("Вес мерника WE_R422")]
        public Single WE_R422 { get { return getValue<Single>(); } }// ad= 5 _ch 3
        [ArchivAttribute("уровень LT_R461")]
        public Single LT_R461 { get { return getValue<Single>(); } }// ad= 7 _ch 4
        [ArchivAttribute("температура TE_K610")]
        public Single TE_K610 { get { return getValue<Single>(); } }// ad= 9 _ch 5
        public Single PIT_P603 { get { return getValue<Single>(); } }// ad= 11 _ch 6
        public Single PIT_P521 { get { return getValue<Single>(); } }// ad= 13 _ch 7
        public Single PIT_P631A { get { return getValue<Single>(); } }// ad= 15 _ch 8
        [ArchivAttribute("pH QE_K610")]                                        //owen mv 8as ad=4      
        public Single QE_K610 { get { return getValue<Single>(); } }// ad= 17 _ch 1
        public Single GE_pHV_K610 { get { return getValue<Single>(); } }// ad= 19 _ch 2
        [ArchivAttribute("температура TE_482")]
        public Single TE_482 { get { return getValue<Single>(); } }// ad= 21 _ch 6
        [ArchivAttribute("температура TE_481_2")]
        public Single TE_E481_Distil { get { return getValue<Single>(); } }// ad= 23 _ch 7
        public Single PIT_P461 { get { return getValue<Single>(); } }// ad= 25 _ch 8
                                                                     //line2_1       
        [ArchivAttribute("pH QIY_K480A")]                                         // owen  8as ad 2      
        public Single QIY_K480A { get { return getValue<Single>(); } }// ad= 27 _ch 1
        [ArchivAttribute("pH QIY_K480B")]
        public Single QIY_K480B { get { return getValue<Single>(); } }// ad= 29 _ch 2
        [ArchivAttribute("pH QIY_K460A")]
        public Single QIY_K460A { get { return getValue<Single>(); } }// ad= 31 _ch 3
        [ArchivAttribute("pH QIY_K460B")]
        public Single QIY_K460B { get { return getValue<Single>(); } }// ad= 33 _ch 4
        [ArchivAttribute("TE_K480A_2")]
        public Single TE_K480A_2 { get { return getValue<Single>(); } }// ad= 35 _ch 5
        [ArchivAttribute("TE_K480B_2")]
        public Single TE_K480B_2 { get { return getValue<Single>(); } }// ad= 37 _ch 6
        [ArchivAttribute("TE_E482_2")]
        public Single TE_E482_2 { get { return getValue<Single>(); } }// ad= 39 _ch 7
                                                                    // owen  8as ad 3      
        public Single PT_480A { get { return getValue<Single>(); } }// ad= 41 _ch 1
        public Single PT_480B { get { return getValue<Single>(); } }// ad= 43 _ch 2
        public Single GE_VK480A_7 { get { return getValue<Single>(); } }// ad= 45 _ch 3
        public Single GE_VK480B_7 { get { return getValue<Single>(); } }// ad= 47 _ch 4
        public Single WE_R402B { get { return getValue<Single>(); } }// ad= 49 _ch 5
        public Single WE_R201B { get { return getValue<Single>(); } }// ad= 51 _ch 6
        public Single WE_R404A { get { return getValue<Single>(); } }// ad= 53 _ch 7
        public Single WE_R403 { get { return getValue<Single>(); } }// ad= 55 _ch 8
        [ArchivAttribute("LE_R481")]                                       // owen  8as ad 4      
        public Single LE_R481 { get { return getValue<Single>(); } }// ad= 57 _ch 1
        public Single WE_D460A { get { return getValue<Single>(); } }// ad= 59 _ch 2
        public Single TE_K460A { get { return getValue<Single>(); } }// ad= 61 _ch 3
        public Single TE_K460B { get { return getValue<Single>(); } }// ad= 63 _ch 4
        public Single FQI_MEK_K480B_MOMENT { get { return getValue<Single>(); } }// ad= 65 _ch 5
        [ArchivAttribute("QE_K450A")]                                            //mv1108as ad=10      
        public Single QE_K450A { get { return getValue<Single>(); } }// ad= 67 _ch 1
        public Single TE_K450A { get { return getValue<Single>(); } }// ad= 69 _ch 2
        [ArchivAttribute("WE_K450A")]
        public Single WE_K450A { get { return getValue<Single>(); } }// ad= 71 _ch 3

        public UInt16 FQ_R521_in_count { get { return getValue<UInt16>(); } } //ad= 73 fast di1
        public UInt16 FQ_K480_in_count { get { return getValue<UInt16>(); } } //ad=74 fast di2
        public UInt16 FQ_K460_in_count { get { return getValue<UInt16>(); } } //ad=75fast di3
        public UInt16 FQ_K450A_MEK_in_count { get { return getValue<UInt16>(); } } //ad=76 fast di4
        public Single TE_480A_1 { get { return getValue<Single>(); } } //ad=77  trm202 ch1
        public Single TE_480B_1 { get { return getValue<Single>(); } } //ad=79 trm202 ch2


        public Single P726_Cur_I{ get { return getValue<Single>(); } } //ad=81
        public Single P726_Cur_FRQ{ get { return getValue<Single>(); } }//ad83
         
        [ArchivAttribute("Вес мерника WE_D470A")]
        public Single WE_D470A_rs { get { return getValue<Single>(); } } //ad=85

        [ArchivAttribute("Вес мерника WE_R201B")]
        public Single WE_R201B_rs { get { return getValue<Single>(); } } //ad=87

        [ArchivAttribute("Вес мерника WE_R404A")]
        public Single WE_R404A_rs { get { return getValue<Single>(); } } //ad=89

        [ArchivAttribute("Вес мерника WE_R402B")]
        public Single WE_R402B_rs { get { return getValue<Single>(); } } //ad=91

        [ArchivAttribute("Вес мерника WE_R403")]
        public Single WE_R403_rs { get { return getValue<Single>(); } } //ad=93

        [ArchivAttribute("счетчик FQ_R521")]
        public Single FQ_R521_in_count_{ get { return getValue<Single>(); } } //ad= 95
        [ArchivAttribute("счетчик FQ_K480")]
        public Single FQ_K480_in_count_{ get { return getValue<Single>(); } } //ad=97
        [ArchivAttribute("счетчик FQ_K460")]
        public Single FQ_K460_in_count_{ get { return getValue<Single>(); } } //ad=99
        public Single FQ_K450A_MEK_in_count_{ get { return getValue<Single>(); } } //ad=101
        [ArchivAttribute("Давление насоса P_726")]
        public Single P_P726{ get { return getValue<Single>(); } }//ad=103
        [ArchivAttribute("Выход на delta cp2000 P726")]
        public Single P726_OUT_Frq{ get { return getValue<Single>(); } } //ad=105

        public UInt16 P726_status { get { return getValue<UInt16>(); } }//ad=107

        public UInt16 NC_K480B_status { get { return getValue<UInt16>(); } }//ad=108
        public Single NC_K480B_OUT_Frq { get { return getValue<UInt16>(); } } //ad=109
        public Single NC_K480B_Cur_I { get { return getValue<Single>(); } } //ad=111
        public Single NC_K480B_Cur_FRQ { get { return getValue<Single>(); } }//ad=113
    

        public UInt16 ZagrMorfolinK480_Operation { get { return getValue<UInt16>(); } } //ad115
        public UInt16 ZagrMorfolinK480_Message { get { return getValue<UInt16>(); } } //ad116
        public Single ZagrMorfolinK480_Doza { get { return getValue<Single>(); } }  //ad117

        public Single TE_E481 { get { return getValue<Single>(); } }//ad119 //трм 202 ad24 1k
        [ArchivAttribute("счетчик TE_K480A_1")]
        public Single TE_K480A_1 { get { return getValue<Single>(); } }//121 //трм 202 ad80 1k
        [ArchivAttribute("счетчик TE_K480B_1")]
        public Single TE_K480B_1 { get { return getValue<Single>(); } }//ad123  //трм 202 ad80 2k

        public Single ZagrDietilK480_Doza { get { return getValue<Single>(); } }  //ad125
        public UInt16 ZagrARtVoda_TimeLeft { get { return getValue<UInt16>(); } } //126
        public UInt16 ZagrGoroda460_TimeLeft { get { return getValue<UInt16>(); } } //127
        public UInt16 ZagrARtVoda480_TimeLeft { get { return getValue<UInt16>(); } } //128

        public UInt16 empty3 { get { return getValue<UInt16>(); } }//129
        public Single NC_K480A_OUT_Frq { get { return getValue<Single>(); } } //ad=130
        public Single NC_K480A_Cur_FRQ { get { return getValue<Single>(); } }//ad=132

        //public Single  { get { return getValue<Single>(); } }
        public Single ZagrDietilAminK480_Doza  { get { return getValue<Single>(); } }//ad134
        public Single WE_D470A_analog { get { return getValue<Single>(); } } //136
        [ArchivAttribute("Счетчик воды на МЭК K480A")]
        public Single emis200_summ_k480A { get { return getValue<Single>(); } }//138
        [ArchivAttribute("Мг-й расход K480A")]
        public Single emis200_FlowMeter_k480A { get { return getValue<Single>(); } }//140
        [ArchivAttribute("Счетчик воды на МЭК K480B")]
        public Single emis200_summ_k480B { get { return getValue<Single>(); } }//142
        [ArchivAttribute("Мг-й расход K480B")]
        public Single emis200_FlowMeter_k480B { get { return getValue<Single>(); } }//144

        public Single ZagrDietilAminK480_Doza2 { get { return getValue<Single>(); } }//ad146
        public Single ZagrAnilin_Doza { get { return getValue<Single>(); } }//ad148

        public Single ZagrVodi_perA { get { return getValue<Single>(); } }//ad150

        public Single Volume_R461 { get { return getValue<Single>(); } }//ad152

        public UInt16 JOURNAL = 13;//  заглушка проверки , убирает защиту от записи в бд при обрыви связи с плк
        public bool testOn = false;//  заглушка проверки , убирает защиту от записи в бд при обрыви связи с плк
                                   //ad108  должен быть последним ,служит для определения успешного чтения регистров
                                   //ad=82 


        #endregion

        // Holdings Registers
        #region Holdings Registers
        //******************line1_1 ********************      
        //mu 110 8i ad=5       
        public UInt16 NC_P412_aout { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }  // ad= 1 _ch 1 
          //mu 110 8i ad=5        //mu 110 8i ad=5        //mu 110 8i ad=5       	//mu 110 8i ad=5       
        public UInt16 NC_610M_aout { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }  // ad= 2 _ch 2 
        public UInt16 pHV_K610_aout { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } } // ad= 3 _ch 3 
        public UInt16 FV_K480A_reg_aout_ { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }    // ad= 4 _ch 4 
        public UInt16 FV_K480B_reg_aout_ { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }    // ad= 5 _ch 5 
                                                                                                                    // ************************line2_1   ***************************     // ************************line2_1   ***************************     // ************************line2_1   ***************************    	// ************************line2_1   ***************************    
                                                                                                                    //mu 110 8i ad=5        //mu 110 8i ad=5        //mu 110 8i ad=5       	//mu 110 8i ad=5       
        public UInt16 VK480A_7_aout_ { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }    // ad= 6 _ch 1 
        public UInt16 VK480B_7_aout_ { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }    // ad= 7 _ch 2 
        public UInt16 TVK480A_aout_ { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } } // ad= 8 _ch 3 
        public UInt16 TVK480B_aout_ { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } } // ad= 9 _ch 4 
        public UInt16 VK480A_1_reg_aout_ { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }    // ad= 10 _ch 5 
        public UInt16 VK480B_1_reg_aout_ { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }    // ad= 11 _ch 6 
                                                                                                                    //mu 110 8i ad=11        //mu 110 8i ad=11        //mu 110 8i ad=11       	//mu 110 8i ad=11       
        public UInt16 pHV_K450A_aout { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }    // ad= 12 _ch 1 
        public UInt16 V_K480A_8_aout { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }    // ad= 13 _ch 2 
        public UInt16 V_K480B_8_aout { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }    // ad= 14 _ch 3 
        public UInt16 V_K480A_9_aout { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }    // ad= 15 _ch 4 
        public UInt16 V_K480B_9_aout { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }    // ad= 16 _ch 5 
        public UInt16 V_K480A_11_aout { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }   // ad= 17 _ch 6 
        public UInt16 V_K480B_11_aout { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }   // ad= 18 _ch 7 
        public UInt16 V_K480A_10_aout { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }   // ad= 19 _ch 8 
                                                                                                                //mu 110 8i ad=12        //mu 110 8i ad=12        //mu 110 8i ad=12       	//mu 110 8i ad=12       
        public UInt16 V_K480B_10_aout { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }   // ad= 20 _ch 1 
        public UInt16 NC_K450A_aout { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } } // ad= 21 _ch 2 
        public UInt16 viravni1 { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }  //ad=22

        public Single NC_M610_ain_auto { get { return getValue<Single>(); } set { setValue<Single>(value); } }  //ad=23 частота мешалки в авто
        public Single NC_M610_ain_man { get { return getValue<Single>(); } set { setValue<Single>(value); } }   //ad=25 частота мешалки в руч

        public Single NC_P412_ain_auto { get { return getValue<Single>(); } set { setValue<Single>(value); } }  //ad=27 частота мешалки в авто
        public Single NC_P412_ain_man { get { return getValue<Single>(); } set { setValue<Single>(value); } }   //ad=29 частота мешалки в руч



        public Single FV_K480B_reg_ain_auto { get { return getValue<Single>(); } set { setValue<Single>(value); } } //ad=31
        public Single FV_K480B_reg_ain_man { get { return getValue<Single>(); } set { setValue<Single>(value); } }  //ad=33

        public Single FV_K480A_reg_ain_auto { get { return getValue<Single>(); } set { setValue<Single>(value); } } //ad=35
        public Single FV_K480A_reg_ain_man { get { return getValue<Single>(); } set { setValue<Single>(value); } }  //ad=37

        public UInt16 ZagrVodaComm_Nemk { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } } //39
        [JournalAttribute(" Загр. арт воды. Изменена уставка дозы воды ")]
        public UInt16 ZagrVodaComm_DozaZad { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }  //40
        public UInt16 ZagrVodaComm_doza { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } } //41
        public UInt16 viravni2 { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }  //42
                                                                                                        //PLC2 valve reg //PLC2 valve reg //PLC2 valve reg	//PLC2 valve reg
        public Single VK480A_7_ain_man { get { return getValue<Single>(); } set { setValue<Single>(value); } }  //43
        public Single VK480A_7_ain_auto { get { return getValue<Single>(); } set { setValue<Single>(value); } } //45

        public Single VK480B_7_ain_man { get { return getValue<Single>(); } set { setValue<Single>(value); } }  //47
        public Single VK480B_7_ain_auto { get { return getValue<Single>(); } set { setValue<Single>(value); } } //49

        public Single VK480A_1_reg_ain_man { get { return getValue<Single>(); } set { setValue<Single>(value); } }  //ad=51
        public Single VK480A_1_reg_ain_auto { get { return getValue<Single>(); } set { setValue<Single>(value); } } //ad=53

        public Single pHV_K450A_ain_man { get { return getValue<Single>(); } set { setValue<Single>(value); } } //ad=55
        public Single pHV_K450A_ain_auto { get { return getValue<Single>(); } set { setValue<Single>(value); } }    //ad=57

        public Single V_K480A_8_ain_man { get { return getValue<Single>(); } set { setValue<Single>(value); } } //ad=59
        public Single V_K480A_8_ain_auto { get { return getValue<Single>(); } set { setValue<Single>(value); } }    //ad=61

        public Single V_K480B_8_ain_man { get { return getValue<Single>(); } set { setValue<Single>(value); } } //ad=63
        public Single V_K480B_8_ain_auto { get { return getValue<Single>(); } set { setValue<Single>(value); } }    //ad=65

        public Single V_K480A_9_ain_man { get { return getValue<Single>(); } set { setValue<Single>(value); } } //ad=67
        public Single V_K480A_9_ain_auto { get { return getValue<Single>(); } set { setValue<Single>(value); } }    //ad=69

        public Single V_K480B_9_ain_man { get { return getValue<Single>(); } set { setValue<Single>(value); } } //ad=71
        public Single V_K480B_9_ain_auto { get { return getValue<Single>(); } set { setValue<Single>(value); } }    //ad=73

        public Single V_K480B_10_ain_man { get { return getValue<Single>(); } set { setValue<Single>(value); } }    //ad=75
        public Single V_K480B_10_ain_auto { get { return getValue<Single>(); } set { setValue<Single>(value); } }   //ad=77

        public Single V_K480B_11_ain_man { get { return getValue<Single>(); } set { setValue<Single>(value); } }    //ad=79
        public Single V_K480B_11_ain_auto { get { return getValue<Single>(); } set { setValue<Single>(value); } }   //ad=81

        public Single V_K480A_10_ain_man { get { return getValue<Single>(); } set { setValue<Single>(value); } }    //ad=83
        public Single V_K480A_10_ain_auto { get { return getValue<Single>(); } set { setValue<Single>(value); } }   //ad=85
        public Single V_K480A_11_ain_man { get { return getValue<Single>(); } set { setValue<Single>(value); } }    //ad=87
        public Single V_K480A_11_ain_auto { get { return getValue<Single>(); } set { setValue<Single>(value); } }   //ad=89

        public Single NC_K450A_ain_auto { get { return getValue<Single>(); } set { setValue<Single>(value); } } //ad=91 частота мешалки в авто
        public Single NC_K450A_ain_man { get { return getValue<Single>(); } set { setValue<Single>(value); } }  //ad=93 частота мешалки в руч

        public Single TVK480A_ain_man { get { return getValue<Single>(); } set { setValue<Single>(value); } }   // 95
        public Single TVK480A_ain_auto { get { return getValue<Single>(); } set { setValue<Single>(value); } }  // 97

        public Single TVK480B_ain_man { get { return getValue<Single>(); } set { setValue<Single>(value); } }   // 99
        public Single TVK480B_ain_auto { get { return getValue<Single>(); } set { setValue<Single>(value); } }  // 101
        public UInt16 test { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }  //103
        public UInt16 test1 { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } } //104
        public UInt16 ZagrKond460Comm_DozaZad { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }   //105
        public UInt16 ZagrKond460Comm_Nemk { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }  //106
        public UInt16 ZagrKond460Comm_doza { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }  //107

        public UInt16 ZagrKond480Comm_DozaZad { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } } //108
        public UInt16 ZagrKond480Comm_Nemk { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } } //109
        public UInt16 ZagrKond480Comm_doza { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }//110

        //from r422
       public Single   fromR422_doza_zad{ get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad=111
       public Single   fromR422_W{ get { return getValue<Single>(); } set { setValue<Single>(value); } } // ad=113
       public Single   fromR422_tau_zad{ get { return getValue<Single>(); } set { setValue<Single>(value); } }// ad=115
       public Single   fromR422_ZonaProp{ get { return getValue<Single>(); } set { setValue<Single>(value); } }// ad=117
       public Single   fromR422_Ti{ get { return getValue<Single>(); } set { setValue<Single>(value); } }// ad=119
       public Single   fromR422_Kd{ get { return getValue<Single>(); } set { setValue<Single>(value); } }// ad=121
       public Single   fromR422_Doza100{ get { return getValue<Single>(); } set { setValue<Single>(value); } }// ad=123
       public Single   fromR422_KoefOper{ get { return getValue<Single>(); } set { setValue<Single>(value); } }// ad=125
       public Single   fromR422_Concentr{ get { return getValue<Single>(); } set { setValue<Single>(value); } }// ad=127
       public Single   fromR422_DoljaZagr1{ get { return getValue<Single>(); } set { setValue<Single>(value); } }// ad=129
       public Single   fromR422_MinProizv{ get { return getValue<Single>(); } set { setValue<Single>(value); } }// ad=131

        public UInt16 fromR422_Message { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }//ad=132
        public  UInt16 fromR422_Operation { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }//ad=133
        public Single fromR422_W_zad{ get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad=134
        public Single fromR422_doza{ get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad=136
        public Single fromR422_doza1{ get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad=138
        public Single fromR422_doza2{ get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad=140
        public Single fromR422_Ostatok{ get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad=142
        public Single fromR422_tau{ get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad=144
        public Single fromR422_tau1{ get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad=146
        public Single fromR422_tau2 { get { return getValue<Single>(); } set { setValue<Single>(value); } }///ad=148

        public Single Ohlagd480_Tzad { get { return getValue<Single>(); } set { setValue<Single>(value); } } //ad 150
        public UInt16 ohlagd480_N_emk { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } } //152
        public UInt16 ohlagd480_N_emk_2 { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } } //153


        public Single man_P726_setFrq{ get { return getValue<Single>(); } set { setValue<Single>(value); } } //ad 154
        public Single SP_P_OUT_P726{ get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad156  
        public Single KP_P_OUT_P726{ get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad157
        public Single TN_P_OUT_P726{ get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad159
        public Single TV_P_OUT_P726{ get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad161



        public Single RegPH480A_x1 { get { return getValue<Single>(); } set { setValue<Single>(value); } } // ad=163
        public Single RegPH480A_x2 { get { return getValue<Single>(); } set { setValue<Single>(value); } } // ad=165
        public Single RegPH480A_x3 { get { return getValue<Single>(); } set { setValue<Single>(value); } } // ad=167
        public Single RegPH480A_x4 { get { return getValue<Single>(); } set { setValue<Single>(value); } } // ad=169
        public Single RegPH480A_x5 { get { return getValue<Single>(); } set { setValue<Single>(value); } } // ad=171
        public Single RegPH480A_pH1 { get { return getValue<Single>(); } set { setValue<Single>(value); } } // ad=173
        public Single RegPH480A_pH2 { get { return getValue<Single>(); } set { setValue<Single>(value); } } // ad=175
        public Single RegPH480A_pH3 { get { return getValue<Single>(); } set { setValue<Single>(value); } }// ad=177
        public Single RegPH480A_pH4 { get { return getValue<Single>(); } set { setValue<Single>(value); } } // ad=179
        public Single RegPH480A_pH5 { get { return getValue<Single>(); } set { setValue<Single>(value); } }// ad=181
        public Single RegPH480A_DeltaPH_max { get { return getValue<Single>(); } set { setValue<Single>(value); } } // ad=183
        public UInt16 RegPH480A_Tau_izm { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }  // ad=185
        public UInt16 RegPH480A_Tau_pause { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }  // ad=186


        public Single RegPH480B_x1 { get { return getValue<Single>(); } set { setValue<Single>(value); } } // ad=187
        public Single RegPH480B_x2 { get { return getValue<Single>(); } set { setValue<Single>(value); } } // ad=189
        public Single RegPH480B_x3 { get { return getValue<Single>(); } set { setValue<Single>(value); } } // ad=191
        public Single RegPH480B_x4 { get { return getValue<Single>(); } set { setValue<Single>(value); } } // ad=193
        public Single RegPH480B_x5 { get { return getValue<Single>(); } set { setValue<Single>(value); } } // ad=195
        public Single RegPH480B_pH1 { get { return getValue<Single>(); } set { setValue<Single>(value); } } // ad=197
        public Single RegPH480B_pH2 { get { return getValue<Single>(); } set { setValue<Single>(value); } } // ad=199
        public Single RegPH480B_pH3 { get { return getValue<Single>(); } set { setValue<Single>(value); } } // ad=201
        public Single RegPH480B_pH4 { get { return getValue<Single>(); } set { setValue<Single>(value); } } // ad=203
        public Single RegPH480B_pH5 { get { return getValue<Single>(); } set { setValue<Single>(value); } } // ad=205
        public Single RegPH480B_DeltaPH_max { get { return getValue<Single>(); } set { setValue<Single>(value); } } // ad=207
        public UInt16 RegPH480B_Tau_izm { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }// ad=209
        public UInt16 RegPH480B_Tau_pause { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } } // ad=210

        public Single RegPH480A_DozaZad { get { return getValue<Single>(); } set { setValue<Single>(value); } } // ad=211
        public Single RegPH480B_DozaZad { get { return getValue<Single>(); } set { setValue<Single>(value); } } // ad=213
        public Single RegPH480A_pH_zad { get { return getValue<Single>(); } set { setValue<Single>(value); } }// ad=215
        public Single RegPH480B_pH_zad { get { return getValue<Single>(); } set { setValue<Single>(value); } } // ad=217
        public Single RegPH480A_Kx { get { return getValue<Single>(); } set { setValue<Single>(value); } }// ad=219
        public Single RegPH480B_Kx { get { return getValue<Single>(); } set { setValue<Single>(value); } } // ad=221
        public Single RegPH480A_doza { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad=223
        public Single RegPH480B_doza { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad=225

        public Single VK480B_1_reg_ain_man { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad=227
        public Single VK480B1_reg_ain_auto { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad=229


        public Single NC_K480B_ain_man { get { return getValue<Single>(); } set { setValue<Single>(value); } }//231
        public Single NC_K480B_ain_auto { get { return getValue<Single>(); } set { setValue<Single>(value); } }//233

        public Single ZagrMorfolinK480_DozaZad { get { return getValue<Single>(); } set { setValue<Single>(value); } }//237
        public Single ZagrMorfolinK480_Xnom{ get { return getValue<Single>(); } set { setValue<Single>(value); } }//239

        public Single ZagrMorfolinK480_Wmin { get { return getValue<Single>(); } set { setValue<Single>(value); } }//241
        public Single ZagrMorfolinK480_percentSurplus { get { return getValue<Single>(); } set { setValue<Single>(value); } }//243
        public Single ResetCount{ get { return getValue<Single>(); } set { setValue<Single>(value); } }//245

        public UInt16 ZagrMorfolinK480_secondsSurplus { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } } //247
        public UInt16 ZagrMorfolinK480_status { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } } //248

        public UInt16 ZagrMorfolinK480_Nemk { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } } //249
        public UInt16 zap { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } } //250

        public Single ZagrMorfol_setDeegrePredictClose { get { return getValue<Single>(); } set { setValue<Single>(value); } }//252

        public Single ZagrDietilK480_DozaZad { get { return getValue<Single>(); } set { setValue<Single>(value); } }//253
        public Single ZagrDietilK480_Xnom { get { return getValue<Single>(); } set { setValue<Single>(value); } }//255
        public Single ZagrDietilK480_Wmin { get { return getValue<Single>(); } set { setValue<Single>(value); } }//257
        public Single ZagrDietil_weightPredictClose { get { return getValue<Single>(); } set { setValue<Single>(value); } }//259
        public UInt16 ZagrDietilK480_status { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }//261
        public UInt16 ZagrDietilK480_Nemk { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }//262
        public Single ZagrDietil_setDeegrePredictClose { get { return getValue<Single>(); } set { setValue<Single>(value); } }//263

        public Single NC_K480A_ain_man { get { return getValue<Single>(); } set { setValue<Single>(value); } }//265
        public Single NC_K480BA_ain_auto { get { return getValue<Single>(); } set { setValue<Single>(value); } }//267

         public Single ZagrDietilAminK480_DozaZad1 { get { return getValue<Single>(); } set { setValue<Single>(value); } }//269
         public Single ZagrDietilAminK480_DozaZad2 { get { return getValue<Single>(); } set { setValue<Single>(value); } }//271
        public Single ZagrDietilAminK480_Xnom { get { return getValue<Single>(); } set { setValue<Single>(value); } }//273
         public Single ZagrDietilAminK480_Wmin { get { return getValue<Single>(); } set { setValue<Single>(value); } }//275
         public Single ZagrDietilAmin_weightPredictClose { get { return getValue<Single>(); } set { setValue<Single>(value); } }//277
        public UInt16 ZagrDietilAminK480_status { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }//279
        public UInt16 ZagrDietilAminK480_Nemk { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }//281
        public Single ZagrDietilAmin_setDeegrePredictClose { get { return getValue<Single>(); } set { setValue<Single>(value); } }//283
        public Single ZagrDietilAminK480_Tnagr { get { return getValue<Single>(); } set { setValue<Single>(value); } }//285
        public Single InceptControl { get { return getValue<Single>(); } set { setValue<Single>(value); } }//287
        public Single pHV_K610_ain_man { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad=289
        public Single pHV_K610_ain_auto { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad=291


        public Single ZagrAnilin480_DozaZad { get { return getValue<Single>(); } set { setValue<Single>(value); } }//293
        public Single ZagrAnilin480_Xnom { get { return getValue<Single>(); } set { setValue<Single>(value); } }//295
        public Single ZagrAnilin480_Wmin { get { return getValue<Single>(); } set { setValue<Single>(value); } }//297
        public Single ZagrAnilin_weightPredictClose { get { return getValue<Single>(); } set { setValue<Single>(value); } }//299
        public UInt16 ZagrAnilin480_status { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }//300
        public UInt16 ZagrAnilin480_Nemk { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }//301
        public Single ZagrAnilin480_setDeegrePredictClose { get { return getValue<Single>(); } set { setValue<Single>(value); } }//302
          
        public Single Tzad_peregon_A { get { return getValue<Single>(); } set { setValue<Single>(value); } }//304
        public Single KP_pregon_A{ get { return getValue<Single>(); } set { setValue<Single>(value); } }//306
        public Single TN_pregon_A{ get { return getValue<Single>(); } set { setValue<Single>(value); } }//308
        public Single TV_pregon_A{ get { return getValue<Single>(); } set { setValue<Single>(value); } }//310

        public Single Vol_Water_perA { get { return getValue<Single>(); } set { setValue<Single>(value); } }//312
        public Single Kp_fq_perA { get { return getValue<Single>(); } set { setValue<Single>(value); } }//314

        public Single Ki_fq_per_A { get { return getValue<Single>(); } set { setValue<Single>(value); } }//316
        public UInt16 time_perA { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }//318
        public UInt16 empty2 { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }//319


        #endregion
    }

}
