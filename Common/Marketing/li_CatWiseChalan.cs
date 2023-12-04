using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_CatWiseChalan
{
    public Li_CatWiseChalan()
    {
    }

    public Li_CatWiseChalan
        (
        
        string libraryID, 
        decimal dak_Bonus, 
        decimal cha_A, 
        decimal cha_B, 
        decimal cha_C, 
        decimal cha_D, 
        decimal cha_E, 
        decimal cha_F, 
        decimal ret_A, 
        decimal ret_B, 
        decimal ret_C, 
        decimal ret_D, 
        decimal ret_E, 
        decimal ret_F, 
        decimal net_ChaA, 
        decimal net_ChaB, 
        decimal net_ChaC, 
        decimal net_ChaD, 
        decimal net_ChaE, 
        decimal net_ChaF, 
        decimal tot_Cha, 
        decimal tot_Ret, 
        decimal tot_Net, 
        decimal tot_Depo, 
        decimal ac_Depo, 
        decimal dak_Chalan, 
        decimal pC_Cost, 
        decimal op_Balance, 
        decimal genB_A, 
        decimal genB_B, 
        decimal genB_C, 
        decimal genB_D, 
        decimal genB_E, 
        decimal genB_F, 
        decimal genB_Tot, 
        decimal bon_Sal, 
        decimal bon_Ret, 
        decimal bon_Depo, 
        decimal total_Bonus, 
        decimal bon_p_Sal, 
        decimal bon_p_Ret, 
        decimal bon_p_Depo, 
        decimal roundUp, 
        int isShow, 
        decimal dakB_A, 
        decimal dakB_B, 
        decimal dakB_C, 
        decimal dakB_D, 
        decimal dakB_E, 
        decimal dakB_F, 
        decimal almB_A, 
        decimal almB_B, 
        decimal almB_C, 
        decimal almB_D, 
        decimal almB_E, 
        decimal almB_F, 
        decimal almChalan, 
        DateTime createdDate, 
        int createdBy  
         
        )
    {
       
        this.LibraryID = libraryID;
        this.Dak_Bonus = dak_Bonus;
        this.Cha_A = cha_A;
        this.Cha_B = cha_B;
        this.Cha_C = cha_C;
        this.Cha_D = cha_D;
        this.Cha_E = cha_E;
        this.Cha_F = cha_F;
        this.Ret_A = ret_A;
        this.Ret_B = ret_B;
        this.Ret_C = ret_C;
        this.Ret_D = ret_D;
        this.Ret_E = ret_E;
        this.Ret_F = ret_F;
        this.Net_ChaA = net_ChaA;
        this.Net_ChaB = net_ChaB;
        this.Net_ChaC = net_ChaC;
        this.Net_ChaD = net_ChaD;
        this.Net_ChaE = net_ChaE;
        this.Net_ChaF = net_ChaF;
        this.Tot_Cha = tot_Cha;
        this.Tot_Ret = tot_Ret;
        this.Tot_Net = tot_Net;
        this.Tot_Depo = tot_Depo;
        this.Ac_Depo = ac_Depo;
        this.Dak_Chalan = dak_Chalan;
        this.PC_Cost = pC_Cost;
        this.Op_Balance = op_Balance;
        this.GenB_A = genB_A;
        this.GenB_B = genB_B;
        this.GenB_C = genB_C;
        this.GenB_D = genB_D;
        this.GenB_E = genB_E;
        this.GenB_F = genB_F;
        this.GenB_Tot = genB_Tot;
        this.Bon_Sal = bon_Sal;
        this.Bon_Ret = bon_Ret;
        this.Bon_Depo = bon_Depo;
        this.Total_Bonus = total_Bonus;
        this.Bon_p_Sal = bon_p_Sal;
        this.Bon_p_Ret = bon_p_Ret;
        this.Bon_p_Depo = bon_p_Depo;
        this.RoundUp = roundUp;
        this.IsShow = isShow;
        this.DakB_A = dakB_A;
        this.DakB_B = dakB_B;
        this.DakB_C = dakB_C;
        this.DakB_D = dakB_D;
        this.DakB_E = dakB_E;
        this.DakB_F = dakB_F;
        this.AlmB_A = almB_A;
        this.AlmB_B = almB_B;
        this.AlmB_C = almB_C;
        this.AlmB_D = almB_D;
        this.AlmB_E = almB_E;
        this.AlmB_F = almB_F;
        this.AlmChalan = almChalan;
        this.CreatedDate = createdDate;
        this.CreatedBy = createdBy;
       
    }


   

    private string _libraryID;
    public string LibraryID
    {
        get { return _libraryID; }
        set { _libraryID = value; }
    }

    private decimal _dak_Bonus;
    public decimal Dak_Bonus
    {
        get { return _dak_Bonus; }
        set { _dak_Bonus = value; }
    }

    private decimal _cha_A;
    public decimal Cha_A
    {
        get { return _cha_A; }
        set { _cha_A = value; }
    }

    private decimal _cha_B;
    public decimal Cha_B
    {
        get { return _cha_B; }
        set { _cha_B = value; }
    }

    private decimal _cha_C;
    public decimal Cha_C
    {
        get { return _cha_C; }
        set { _cha_C = value; }
    }

    private decimal _cha_D;
    public decimal Cha_D
    {
        get { return _cha_D; }
        set { _cha_D = value; }
    }

    private decimal _cha_E;
    public decimal Cha_E
    {
        get { return _cha_E; }
        set { _cha_E = value; }
    }

    private decimal _cha_F;
    public decimal Cha_F
    {
        get { return _cha_F; }
        set { _cha_F = value; }
    }

    private decimal _ret_A;
    public decimal Ret_A
    {
        get { return _ret_A; }
        set { _ret_A = value; }
    }

    private decimal _ret_B;
    public decimal Ret_B
    {
        get { return _ret_B; }
        set { _ret_B = value; }
    }

    private decimal _ret_C;
    public decimal Ret_C
    {
        get { return _ret_C; }
        set { _ret_C = value; }
    }

    private decimal _ret_D;
    public decimal Ret_D
    {
        get { return _ret_D; }
        set { _ret_D = value; }
    }

    private decimal _ret_E;
    public decimal Ret_E
    {
        get { return _ret_E; }
        set { _ret_E = value; }
    }

    private decimal _ret_F;
    public decimal Ret_F
    {
        get { return _ret_F; }
        set { _ret_F = value; }
    }

    private decimal _net_ChaA;
    public decimal Net_ChaA
    {
        get { return _net_ChaA; }
        set { _net_ChaA = value; }
    }

    private decimal _net_ChaB;
    public decimal Net_ChaB
    {
        get { return _net_ChaB; }
        set { _net_ChaB = value; }
    }

    private decimal _net_ChaC;
    public decimal Net_ChaC
    {
        get { return _net_ChaC; }
        set { _net_ChaC = value; }
    }

    private decimal _net_ChaD;
    public decimal Net_ChaD
    {
        get { return _net_ChaD; }
        set { _net_ChaD = value; }
    }

    private decimal _net_ChaE;
    public decimal Net_ChaE
    {
        get { return _net_ChaE; }
        set { _net_ChaE = value; }
    }

    private decimal _net_ChaF;
    public decimal Net_ChaF
    {
        get { return _net_ChaF; }
        set { _net_ChaF = value; }
    }

    private decimal _tot_Cha;
    public decimal Tot_Cha
    {
        get { return _tot_Cha; }
        set { _tot_Cha = value; }
    }

    private decimal _tot_Ret;
    public decimal Tot_Ret
    {
        get { return _tot_Ret; }
        set { _tot_Ret = value; }
    }

    private decimal _tot_Net;
    public decimal Tot_Net
    {
        get { return _tot_Net; }
        set { _tot_Net = value; }
    }

    private decimal _tot_Depo;
    public decimal Tot_Depo
    {
        get { return _tot_Depo; }
        set { _tot_Depo = value; }
    }

    private decimal _ac_Depo;
    public decimal Ac_Depo
    {
        get { return _ac_Depo; }
        set { _ac_Depo = value; }
    }

    private decimal _dak_Chalan;
    public decimal Dak_Chalan
    {
        get { return _dak_Chalan; }
        set { _dak_Chalan = value; }
    }

    private decimal _pC_Cost;
    public decimal PC_Cost
    {
        get { return _pC_Cost; }
        set { _pC_Cost = value; }
    }

    private decimal _op_Balance;
    public decimal Op_Balance
    {
        get { return _op_Balance; }
        set { _op_Balance = value; }
    }

    private decimal _genB_A;
    public decimal GenB_A
    {
        get { return _genB_A; }
        set { _genB_A = value; }
    }

    private decimal _genB_B;
    public decimal GenB_B
    {
        get { return _genB_B; }
        set { _genB_B = value; }
    }

    private decimal _genB_C;
    public decimal GenB_C
    {
        get { return _genB_C; }
        set { _genB_C = value; }
    }

    private decimal _genB_D;
    public decimal GenB_D
    {
        get { return _genB_D; }
        set { _genB_D = value; }
    }

    private decimal _genB_E;
    public decimal GenB_E
    {
        get { return _genB_E; }
        set { _genB_E = value; }
    }

    private decimal _genB_F;
    public decimal GenB_F
    {
        get { return _genB_F; }
        set { _genB_F = value; }
    }

    private decimal _genB_Tot;
    public decimal GenB_Tot
    {
        get { return _genB_Tot; }
        set { _genB_Tot = value; }
    }

    private decimal _bon_Sal;
    public decimal Bon_Sal
    {
        get { return _bon_Sal; }
        set { _bon_Sal = value; }
    }

    private decimal _bon_Ret;
    public decimal Bon_Ret
    {
        get { return _bon_Ret; }
        set { _bon_Ret = value; }
    }

    private decimal _bon_Depo;
    public decimal Bon_Depo
    {
        get { return _bon_Depo; }
        set { _bon_Depo = value; }
    }

    private decimal _total_Bonus;
    public decimal Total_Bonus
    {
        get { return _total_Bonus; }
        set { _total_Bonus = value; }
    }

    private decimal _bon_p_Sal;
    public decimal Bon_p_Sal
    {
        get { return _bon_p_Sal; }
        set { _bon_p_Sal = value; }
    }

    private decimal _bon_p_Ret;
    public decimal Bon_p_Ret
    {
        get { return _bon_p_Ret; }
        set { _bon_p_Ret = value; }
    }

    private decimal _bon_p_Depo;
    public decimal Bon_p_Depo
    {
        get { return _bon_p_Depo; }
        set { _bon_p_Depo = value; }
    }

    private decimal _roundUp;
    public decimal RoundUp
    {
        get { return _roundUp; }
        set { _roundUp = value; }
    }

    private int _isShow;
    public int IsShow
    {
        get { return _isShow; }
        set { _isShow = value; }
    }

    private decimal _dakB_A;
    public decimal DakB_A
    {
        get { return _dakB_A; }
        set { _dakB_A = value; }
    }

    private decimal _dakB_B;
    public decimal DakB_B
    {
        get { return _dakB_B; }
        set { _dakB_B = value; }
    }

    private decimal _dakB_C;
    public decimal DakB_C
    {
        get { return _dakB_C; }
        set { _dakB_C = value; }
    }

    private decimal _dakB_D;
    public decimal DakB_D
    {
        get { return _dakB_D; }
        set { _dakB_D = value; }
    }

    private decimal _dakB_E;
    public decimal DakB_E
    {
        get { return _dakB_E; }
        set { _dakB_E = value; }
    }

    private decimal _dakB_F;
    public decimal DakB_F
    {
        get { return _dakB_F; }
        set { _dakB_F = value; }
    }

    private decimal _almB_A;
    public decimal AlmB_A
    {
        get { return _almB_A; }
        set { _almB_A = value; }
    }

    private decimal _almB_B;
    public decimal AlmB_B
    {
        get { return _almB_B; }
        set { _almB_B = value; }
    }

    private decimal _almB_C;
    public decimal AlmB_C
    {
        get { return _almB_C; }
        set { _almB_C = value; }
    }

    private decimal _almB_D;
    public decimal AlmB_D
    {
        get { return _almB_D; }
        set { _almB_D = value; }
    }

    private decimal _almB_E;
    public decimal AlmB_E
    {
        get { return _almB_E; }
        set { _almB_E = value; }
    }

    private decimal _almB_F;
    public decimal AlmB_F
    {
        get { return _almB_F; }
        set { _almB_F = value; }
    }

    private decimal _almChalan;
    public decimal AlmChalan
    {
        get { return _almChalan; }
        set { _almChalan = value; }
    }

    private DateTime _createdDate;
    public DateTime CreatedDate
    {
        get { return _createdDate; }
        set { _createdDate = value; }
    }

    private int _createdBy;
    public int CreatedBy
    {
        get { return _createdBy; }
        set { _createdBy = value; }
    }

    
}
