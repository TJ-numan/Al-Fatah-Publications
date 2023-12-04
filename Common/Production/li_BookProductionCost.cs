using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_BookProductionCost
{
    public Li_BookProductionCost()
    {
    }

    public Li_BookProductionCost
        (
         string bookCode,
        decimal writerBillRate,
        decimal editingRate,
        decimal composingRate,
        decimal proofRate,
        string proofTimes,
        decimal pesting,
        decimal coverDesign,
        decimal innerDesign,
        decimal illustration,
        decimal coverPlateRate,
        int coverPlateQty,
        decimal coverPlateProcesingRate,
        decimal innerPlateRate,
        int innerPlateQty,
        decimal innerPlateProcessingRate,
          decimal formaPlateRate,
        decimal formaPlateQty,
        decimal formaPlateProcessingRate,
        decimal coverPaperQty,
        decimal coverPaperRate,
        decimal innerPaperQty,
        decimal innerPaperRate,
        decimal formaPaperQty,
        decimal formaPaperRate,
        decimal coverPrintRate,
        decimal innerPrintRate,
        decimal formaPrintRate,
        decimal coverLaminationRate,
        decimal coverCreaseRate,
        decimal bookBindingRate,
        decimal bookTransportRate

        )
    {
        this.BookCode = bookCode;
        this.WriterBillRate = writerBillRate;
        this.EditingRate = editingRate;
        this.ComposingRate = composingRate;
        this.ProofRate = proofRate;
        this.ProofTimes = proofTimes;
        this.Pesting = pesting;
        this.CoverDesign = coverDesign;
        this.InnerDesign = innerDesign;
        this.Illustration = illustration;
        this.CoverPlateRate = coverPlateRate;
        this.CoverPlateQty = coverPlateQty;
        this.CoverPlateProcesingRate = coverPlateProcesingRate;
        this.InnerPlateRate = innerPlateRate;
        this.InnerPlateQty = innerPlateQty;

        this.FormaPlateRate = formaPlateRate;
        this.FormaPlateQty = formaPlateQty;
        this.InnerPlateProcessingRate = innerPlateProcessingRate;
        this.FormaPlateProcessingRate = formaPlateProcessingRate;
        this.CoverPaperQty = coverPaperQty;
        this.CoverPaperRate = coverPaperRate;
        this.InnerPaperQty = innerPaperQty;
        this.InnerPaperRate = innerPaperRate;
        this.FormaPaperQty = formaPaperQty;
        this.FormaPaperRate = formaPaperRate;
        this.CoverPrintRate = coverPrintRate;
        this.InnerPrintRate = innerPrintRate;
        this.FormaPrintRate = formaPrintRate;
        this.CoverLaminationRate = coverLaminationRate;
        this.CoverCreaseRate = coverCreaseRate;
        this.BookBindingRate = bookBindingRate;
        this.BookTransportRate = bookTransportRate;
    }




    private string _bookCode;
    public string BookCode
    {
        get { return _bookCode; }
        set { _bookCode = value; }
    }

    private decimal _writerBillRate;
    public decimal WriterBillRate
    {
        get { return _writerBillRate; }
        set { _writerBillRate = value; }
    }

    private decimal _editingRate;
    public decimal EditingRate
    {
        get { return _editingRate; }
        set { _editingRate = value; }
    }

    private decimal _composingRate;
    public decimal ComposingRate
    {
        get { return _composingRate; }
        set { _composingRate = value; }
    }

    private decimal _proofRate;
    public decimal ProofRate
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

    private decimal _pesting;
    public decimal Pesting
    {
        get { return _pesting; }
        set { _pesting = value; }
    }

    private decimal _coverDesign;
    public decimal CoverDesign
    {
        get { return _coverDesign; }
        set { _coverDesign = value; }
    }

    private decimal _innerDesign;
    public decimal InnerDesign
    {
        get { return _innerDesign; }
        set { _innerDesign = value; }
    }

    private decimal _illustration;
    public decimal Illustration
    {
        get { return _illustration; }
        set { _illustration = value; }
    }

    private decimal _coverPlateRate;
    public decimal CoverPlateRate
    {
        get { return _coverPlateRate; }
        set { _coverPlateRate = value; }
    }

    private int _coverPlateQty;
    public int CoverPlateQty
    {
        get { return _coverPlateQty; }
        set { _coverPlateQty = value; }
    }

    private decimal _coverPlateProcesingRate;
    public decimal CoverPlateProcesingRate
    {
        get { return _coverPlateProcesingRate; }
        set { _coverPlateProcesingRate = value; }
    }

    private decimal _innerPlateRate;
    public decimal InnerPlateRate
    {
        get { return _innerPlateRate; }
        set { _innerPlateRate = value; }
    }

    private int _innerPlateQty;
    public int InnerPlateQty
    {
        get { return _innerPlateQty; }
        set { _innerPlateQty = value; }
    }
private decimal _formaPlateRate;
    public decimal FormaPlateRate
    {
        get { return _formaPlateRate; }
        set { _formaPlateRate = value; }
    }

    private decimal  _formaPlateQty;
    public decimal FormaPlateQty
    {
        get { return _formaPlateQty; }
        set { _formaPlateQty = value; }
    }

    private decimal _innerPlateProcessingRate;
    public decimal InnerPlateProcessingRate
    {
        get { return _innerPlateProcessingRate; }
        set { _innerPlateProcessingRate = value; }
    }

    private decimal _formaPlateProcessingRate;
    public decimal FormaPlateProcessingRate
    {
        get { return _formaPlateProcessingRate; }
        set { _formaPlateProcessingRate = value; }
    }

    private decimal _coverPaperQty;
    public decimal CoverPaperQty
    {
        get { return _coverPaperQty; }
        set { _coverPaperQty = value; }
    }

    private decimal _coverPaperRate;
    public decimal CoverPaperRate
    {
        get { return _coverPaperRate; }
        set { _coverPaperRate = value; }
    }

    private decimal _innerPaperQty;
    public decimal InnerPaperQty
    {
        get { return _innerPaperQty; }
        set { _innerPaperQty = value; }
    }

    private decimal _innerPaperRate;
    public decimal InnerPaperRate
    {
        get { return _innerPaperRate; }
        set { _innerPaperRate = value; }
    }

    private decimal _formaPaperQty;
    public decimal FormaPaperQty
    {
        get { return _formaPaperQty; }
        set { _formaPaperQty = value; }
    }

    private decimal _formaPaperRate;
    public decimal FormaPaperRate
    {
        get { return _formaPaperRate; }
        set { _formaPaperRate = value; }
    }

    private decimal _coverPrintRate;
    public decimal CoverPrintRate
    {
        get { return _coverPrintRate; }
        set { _coverPrintRate = value; }
    }

    private decimal _innerPrintRate;
    public decimal InnerPrintRate
    {
        get { return _innerPrintRate; }
        set { _innerPrintRate = value; }
    }

    private decimal _formaPrintRate;
    public decimal FormaPrintRate
    {
        get { return _formaPrintRate; }
        set { _formaPrintRate = value; }
    }

    private decimal _coverLaminationRate;
    public decimal CoverLaminationRate
    {
        get { return _coverLaminationRate; }
        set { _coverLaminationRate = value; }
    }

    private decimal _coverCreaseRate;
    public decimal CoverCreaseRate
    {
        get { return _coverCreaseRate; }
        set { _coverCreaseRate = value; }
    }

    private decimal _bookBindingRate;
    public decimal BookBindingRate
    {
        get { return _bookBindingRate; }
        set { _bookBindingRate = value; }
    }

    private decimal _bookTransportRate;
    public decimal BookTransportRate
    {
        get { return _bookTransportRate; }
        set { _bookTransportRate = value; }
    }

}
