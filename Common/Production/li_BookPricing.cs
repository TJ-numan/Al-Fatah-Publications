using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_BookPricing
{
    public Li_BookPricing()
    {
    }

    public Li_BookPricing
        (
        
        string bookCode, 
        string bookName, 
        string bookForma, 
        string bookSize, 
        string bookQty, 
        string bookEddition, 
        string laminationType, 
        string bindingType, 
        bool isCreasing, 
        string coverPaper, 
        string coverColor, 
        string coverSize, 
        string coverWeight, 
        string coverBrand, 
        string innerSize, 
        string innerArt4Color, 
        string innerOffset4Qty, 
        string innerOffset2Qty, 
        string innerNewsPaper, 
        string innerArt4ColorWeight, 
        string innerOffset4QtyWeight, 
        string innerOffset2QtyWeight, 
        string innerNewsPaperWeight, 
        string formaPaper, 
        string formaColor, 
        string formaSize, 
        string formaWeight, 
        string formaBrand, 
        string writerBillType, 
        string writerRate, 
        string editRate, 
        string composeRate, 
        string proofRate, 
        string proofTimes, 
        string laminationRate, 
        string bindingRate, 
        string coverPrintRate, 
        string innerPrintRate, 
        string formaPrintRate, 
        string manufacturingOver, 
        string administrativeOver, 
        string mKTPromotionalOver, 
        string wastage, 
        string bonus, 
        string commission, 
        string markUp, 
        string coverPageQty, 
        string coverPageRate, 
        string coverAmount, 
        string innerPaperQty, 
        string innerPaperRate, 
        string innerPaperAmount, 
        string formaPaperQty, 
        string formaPaperRate, 
        string formaPaperAmount, 
        string writerBill, 
        string editingCharge, 
        string proofCharge, 
        string composingCharge, 
        string coverDesign, 
        string innerDesign, 
        string illustration, 
        string coverPlateCharge, 
        string innerPlateCharge, 
        string formaPlateCharge, 
        string coverPrint, 
        string innerPrint, 
        string formaPrint, 
        string laminationBill, 
        string bindingBill, 
        string totalDirectCost, 
        string directCostPerBook, 
        string totalCostOfSales, 
        string finalRevenue, 
        string netPrice, 
        string writtenPrice, 
        string tCSPerforma, 
        string finalRevenuePerForma, 
        string formaPaperUnit, 
        string mRPpPerForma, 
        string paperCostTotal, 
        string prePressTotal, 
        string printingTotal, 
        string postPressTotal, 
        int createdBy, 
        DateTime createdDate 
         
        )
    {
       
        this.BookCode = bookCode;
        this.BookName = bookName;
        this.BookForma = bookForma;
        this.BookSize = bookSize;
        this.BookQty = bookQty;
        this.BookEddition = bookEddition;
        this.LaminationType = laminationType;
        this.BindingType = bindingType;
        this.IsCreasing = isCreasing;
        this.CoverPaper = coverPaper;
        this.CoverColor = coverColor;
        this.CoverSize = coverSize;
        this.CoverWeight = coverWeight;
        this.CoverBrand = coverBrand;
        this.InnerSize = innerSize;
        this.InnerArt4Color = innerArt4Color;
        this.InnerOffset4Qty = innerOffset4Qty;
        this.InnerOffset2Qty = innerOffset2Qty;
        this.InnerNewsPaper = innerNewsPaper;
        this.InnerArt4ColorWeight = innerArt4ColorWeight;
        this.InnerOffset4QtyWeight = innerOffset4QtyWeight;
        this.InnerOffset2QtyWeight = innerOffset2QtyWeight;
        this.InnerNewsPaperWeight = innerNewsPaperWeight;
        this.FormaPaper = formaPaper;
        this.FormaColor = formaColor;
        this.FormaSize = formaSize;
        this.FormaWeight = formaWeight;
        this.FormaBrand = formaBrand;
        this.WriterBillType = writerBillType;
        this.WriterRate = writerRate;
        this.EditRate = editRate;
        this.ComposeRate = composeRate;
        this.ProofRate = proofRate;
        this.ProofTimes = proofTimes;
        this.LaminationRate = laminationRate;
        this.BindingRate = bindingRate;
        this.CoverPrintRate = coverPrintRate;
        this.InnerPrintRate = innerPrintRate;
        this.FormaPrintRate = formaPrintRate;
        this.ManufacturingOver = manufacturingOver;
        this.AdministrativeOver = administrativeOver;
        this.MKTPromotionalOver = mKTPromotionalOver;
        this.Wastage = wastage;
        this.Bonus = bonus;
        this.Commission = commission;
        this.MarkUp = markUp;
        this.CoverPageQty = coverPageQty;
        this.CoverPageRate = coverPageRate;
        this.CoverAmount = coverAmount;
        this.InnerPaperQty = innerPaperQty;
        this.InnerPaperRate = innerPaperRate;
        this.InnerPaperAmount = innerPaperAmount;
        this.FormaPaperQty = formaPaperQty;
        this.FormaPaperRate = formaPaperRate;
        this.FormaPaperAmount = formaPaperAmount;
        this.WriterBill = writerBill;
        this.EditingCharge = editingCharge;
        this.ProofCharge = proofCharge;
        this.ComposingCharge = composingCharge;
        this.CoverDesign = coverDesign;
        this.InnerDesign = innerDesign;
        this.Illustration = illustration;
        this.CoverPlateCharge = coverPlateCharge;
        this.InnerPlateCharge = innerPlateCharge;
        this.FormaPlateCharge = formaPlateCharge;
        this.CoverPrint = coverPrint;
        this.InnerPrint = innerPrint;
        this.FormaPrint = formaPrint;
        this.LaminationBill = laminationBill;
        this.BindingBill = bindingBill;
        this.TotalDirectCost = totalDirectCost;
        this.DirectCostPerBook = directCostPerBook;
        this.TotalCostOfSales = totalCostOfSales;
        this.FinalRevenue = finalRevenue;
        this.NetPrice = netPrice;
        this.WrittenPrice = writtenPrice;
        this.TCSPerforma = tCSPerforma;
        this.FinalRevenuePerForma = finalRevenuePerForma;
        this.FormaPaperUnit = formaPaperUnit;
        this.MRPpPerForma = mRPpPerForma;
        this.PaperCostTotal = paperCostTotal;
        this.PrePressTotal = prePressTotal;
        this.PrintingTotal = printingTotal;
        this.PostPressTotal = postPressTotal;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
         
    }


    

    private string _bookCode;
    public string BookCode
    {
        get { return _bookCode; }
        set { _bookCode = value; }
    }

    private string _bookName;
    public string BookName
    {
        get { return _bookName; }
        set { _bookName = value; }
    }

    private string _bookForma;
    public string BookForma
    {
        get { return _bookForma; }
        set { _bookForma = value; }
    }

    private string _bookSize;
    public string BookSize
    {
        get { return _bookSize; }
        set { _bookSize = value; }
    }

    private string _bookQty;
    public string BookQty
    {
        get { return _bookQty; }
        set { _bookQty = value; }
    }

    private string _bookEddition;
    public string BookEddition
    {
        get { return _bookEddition; }
        set { _bookEddition = value; }
    }

    private string _laminationType;
    public string LaminationType
    {
        get { return _laminationType; }
        set { _laminationType = value; }
    }

    private string _bindingType;
    public string BindingType
    {
        get { return _bindingType; }
        set { _bindingType = value; }
    }

    private bool _isCreasing;
    public bool IsCreasing
    {
        get { return _isCreasing; }
        set { _isCreasing = value; }
    }

    private string _coverPaper;
    public string CoverPaper
    {
        get { return _coverPaper; }
        set { _coverPaper = value; }
    }

    private string _coverColor;
    public string CoverColor
    {
        get { return _coverColor; }
        set { _coverColor = value; }
    }

    private string _coverSize;
    public string CoverSize
    {
        get { return _coverSize; }
        set { _coverSize = value; }
    }

    private string _coverWeight;
    public string CoverWeight
    {
        get { return _coverWeight; }
        set { _coverWeight = value; }
    }

    private string _coverBrand;
    public string CoverBrand
    {
        get { return _coverBrand; }
        set { _coverBrand = value; }
    }

    private string _innerSize;
    public string InnerSize
    {
        get { return _innerSize; }
        set { _innerSize = value; }
    }

    private string _innerArt4Color;
    public string InnerArt4Color
    {
        get { return _innerArt4Color; }
        set { _innerArt4Color = value; }
    }

    private string _innerOffset4Qty;
    public string InnerOffset4Qty
    {
        get { return _innerOffset4Qty; }
        set { _innerOffset4Qty = value; }
    }

    private string _innerOffset2Qty;
    public string InnerOffset2Qty
    {
        get { return _innerOffset2Qty; }
        set { _innerOffset2Qty = value; }
    }

    private string _innerNewsPaper;
    public string InnerNewsPaper
    {
        get { return _innerNewsPaper; }
        set { _innerNewsPaper = value; }
    }

    private string _innerArt4ColorWeight;
    public string InnerArt4ColorWeight
    {
        get { return _innerArt4ColorWeight; }
        set { _innerArt4ColorWeight = value; }
    }

    private string _innerOffset4QtyWeight;
    public string InnerOffset4QtyWeight
    {
        get { return _innerOffset4QtyWeight; }
        set { _innerOffset4QtyWeight = value; }
    }

    private string _innerOffset2QtyWeight;
    public string InnerOffset2QtyWeight
    {
        get { return _innerOffset2QtyWeight; }
        set { _innerOffset2QtyWeight = value; }
    }

    private string _innerNewsPaperWeight;
    public string InnerNewsPaperWeight
    {
        get { return _innerNewsPaperWeight; }
        set { _innerNewsPaperWeight = value; }
    }

    private string _formaPaper;
    public string FormaPaper
    {
        get { return _formaPaper; }
        set { _formaPaper = value; }
    }

    private string _formaColor;
    public string FormaColor
    {
        get { return _formaColor; }
        set { _formaColor = value; }
    }

    private string _formaSize;
    public string FormaSize
    {
        get { return _formaSize; }
        set { _formaSize = value; }
    }

    private string _formaWeight;
    public string FormaWeight
    {
        get { return _formaWeight; }
        set { _formaWeight = value; }
    }

    private string _formaBrand;
    public string FormaBrand
    {
        get { return _formaBrand; }
        set { _formaBrand = value; }
    }

    private string _writerBillType;
    public string WriterBillType
    {
        get { return _writerBillType; }
        set { _writerBillType = value; }
    }

    private string _writerRate;
    public string WriterRate
    {
        get { return _writerRate; }
        set { _writerRate = value; }
    }

    private string _editRate;
    public string EditRate
    {
        get { return _editRate; }
        set { _editRate = value; }
    }

    private string _composeRate;
    public string ComposeRate
    {
        get { return _composeRate; }
        set { _composeRate = value; }
    }

    private string _proofRate;
    public string ProofRate
    {
        get { return _proofRate; }
        set { _proofRate = value; }
    }

    private string _proofTimes;
    public string ProofTimes
    {
        get { return _proofTimes; }
        set { _proofTimes = value; }
    }

    private string _laminationRate;
    public string LaminationRate
    {
        get { return _laminationRate; }
        set { _laminationRate = value; }
    }

    private string _bindingRate;
    public string BindingRate
    {
        get { return _bindingRate; }
        set { _bindingRate = value; }
    }

    private string _coverPrintRate;
    public string CoverPrintRate
    {
        get { return _coverPrintRate; }
        set { _coverPrintRate = value; }
    }

    private string _innerPrintRate;
    public string InnerPrintRate
    {
        get { return _innerPrintRate; }
        set { _innerPrintRate = value; }
    }

    private string _formaPrintRate;
    public string FormaPrintRate
    {
        get { return _formaPrintRate; }
        set { _formaPrintRate = value; }
    }

    private string _manufacturingOver;
    public string ManufacturingOver
    {
        get { return _manufacturingOver; }
        set { _manufacturingOver = value; }
    }

    private string _administrativeOver;
    public string AdministrativeOver
    {
        get { return _administrativeOver; }
        set { _administrativeOver = value; }
    }

    private string _mKTPromotionalOver;
    public string MKTPromotionalOver
    {
        get { return _mKTPromotionalOver; }
        set { _mKTPromotionalOver = value; }
    }

    private string _wastage;
    public string Wastage
    {
        get { return _wastage; }
        set { _wastage = value; }
    }

    private string _bonus;
    public string Bonus
    {
        get { return _bonus; }
        set { _bonus = value; }
    }

    private string _commission;
    public string Commission
    {
        get { return _commission; }
        set { _commission = value; }
    }

    private string _markUp;
    public string MarkUp
    {
        get { return _markUp; }
        set { _markUp = value; }
    }

    private string _coverPageQty;
    public string CoverPageQty
    {
        get { return _coverPageQty; }
        set { _coverPageQty = value; }
    }

    private string _coverPageRate;
    public string CoverPageRate
    {
        get { return _coverPageRate; }
        set { _coverPageRate = value; }
    }

    private string _coverAmount;
    public string CoverAmount
    {
        get { return _coverAmount; }
        set { _coverAmount = value; }
    }

    private string _innerPaperQty;
    public string InnerPaperQty
    {
        get { return _innerPaperQty; }
        set { _innerPaperQty = value; }
    }

    private string _innerPaperRate;
    public string InnerPaperRate
    {
        get { return _innerPaperRate; }
        set { _innerPaperRate = value; }
    }

    private string _innerPaperAmount;
    public string InnerPaperAmount
    {
        get { return _innerPaperAmount; }
        set { _innerPaperAmount = value; }
    }

    private string _formaPaperQty;
    public string FormaPaperQty
    {
        get { return _formaPaperQty; }
        set { _formaPaperQty = value; }
    }

    private string _formaPaperRate;
    public string FormaPaperRate
    {
        get { return _formaPaperRate; }
        set { _formaPaperRate = value; }
    }

    private string _formaPaperAmount;
    public string FormaPaperAmount
    {
        get { return _formaPaperAmount; }
        set { _formaPaperAmount = value; }
    }

    private string _writerBill;
    public string WriterBill
    {
        get { return _writerBill; }
        set { _writerBill = value; }
    }

    private string _editingCharge;
    public string EditingCharge
    {
        get { return _editingCharge; }
        set { _editingCharge = value; }
    }

    private string _proofCharge;
    public string ProofCharge
    {
        get { return _proofCharge; }
        set { _proofCharge = value; }
    }

    private string _composingCharge;
    public string ComposingCharge
    {
        get { return _composingCharge; }
        set { _composingCharge = value; }
    }

    private string _coverDesign;
    public string CoverDesign
    {
        get { return _coverDesign; }
        set { _coverDesign = value; }
    }

    private string _innerDesign;
    public string InnerDesign
    {
        get { return _innerDesign; }
        set { _innerDesign = value; }
    }

    private string _illustration;
    public string Illustration
    {
        get { return _illustration; }
        set { _illustration = value; }
    }

    private string _coverPlateCharge;
    public string CoverPlateCharge
    {
        get { return _coverPlateCharge; }
        set { _coverPlateCharge = value; }
    }

    private string _innerPlateCharge;
    public string InnerPlateCharge
    {
        get { return _innerPlateCharge; }
        set { _innerPlateCharge = value; }
    }

    private string _formaPlateCharge;
    public string FormaPlateCharge
    {
        get { return _formaPlateCharge; }
        set { _formaPlateCharge = value; }
    }

    private string _coverPrint;
    public string CoverPrint
    {
        get { return _coverPrint; }
        set { _coverPrint = value; }
    }

    private string _innerPrint;
    public string InnerPrint
    {
        get { return _innerPrint; }
        set { _innerPrint = value; }
    }

    private string _formaPrint;
    public string FormaPrint
    {
        get { return _formaPrint; }
        set { _formaPrint = value; }
    }

    private string _laminationBill;
    public string LaminationBill
    {
        get { return _laminationBill; }
        set { _laminationBill = value; }
    }

    private string _bindingBill;
    public string BindingBill
    {
        get { return _bindingBill; }
        set { _bindingBill = value; }
    }

    private string _totalDirectCost;
    public string TotalDirectCost
    {
        get { return _totalDirectCost; }
        set { _totalDirectCost = value; }
    }

    private string _directCostPerBook;
    public string DirectCostPerBook
    {
        get { return _directCostPerBook; }
        set { _directCostPerBook = value; }
    }

    private string _totalCostOfSales;
    public string TotalCostOfSales
    {
        get { return _totalCostOfSales; }
        set { _totalCostOfSales = value; }
    }

    private string _finalRevenue;
    public string FinalRevenue
    {
        get { return _finalRevenue; }
        set { _finalRevenue = value; }
    }

    private string _netPrice;
    public string NetPrice
    {
        get { return _netPrice; }
        set { _netPrice = value; }
    }

    private string _writtenPrice;
    public string WrittenPrice
    {
        get { return _writtenPrice; }
        set { _writtenPrice = value; }
    }

    private string _tCSPerforma;
    public string TCSPerforma
    {
        get { return _tCSPerforma; }
        set { _tCSPerforma = value; }
    }

    private string _finalRevenuePerForma;
    public string FinalRevenuePerForma
    {
        get { return _finalRevenuePerForma; }
        set { _finalRevenuePerForma = value; }
    }

    private string _formaPaperUnit;
    public string FormaPaperUnit
    {
        get { return _formaPaperUnit; }
        set { _formaPaperUnit = value; }
    }

    private string _mRPpPerForma;
    public string MRPpPerForma
    {
        get { return _mRPpPerForma; }
        set { _mRPpPerForma = value; }
    }

    private string _paperCostTotal;
    public string PaperCostTotal
    {
        get { return _paperCostTotal; }
        set { _paperCostTotal = value; }
    }

    private string _prePressTotal;
    public string PrePressTotal
    {
        get { return _prePressTotal; }
        set { _prePressTotal = value; }
    }

    private string _printingTotal;
    public string PrintingTotal
    {
        get { return _printingTotal; }
        set { _printingTotal = value; }
    }

    private string _postPressTotal;
    public string PostPressTotal
    {
        get { return _postPressTotal; }
        set { _postPressTotal = value; }
    }

    private int _createdBy;
    public int CreatedBy
    {
        get { return _createdBy; }
        set { _createdBy = value; }
    }

    private DateTime _createdDate;
    public DateTime CreatedDate
    {
        get { return _createdDate; }
        set { _createdDate = value; }
    }

    
}
