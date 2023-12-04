using System;
using System.Data;
using System.Configuration;
using System.Linq;




public class li_Edition
{
    public li_Edition()
    {
    }

public li_Edition
        (
int  editonID,
string  editionName,
string  editionDescription

        )

    {
this.EditonID = editonID;
this.EditionName = editionName;
this.EditionDescription = editionDescription;

    }

    private int  _editonID;
    public int  EditonID
    {
        get { return _editonID; }
        set { _editonID = value; }
    }

    private string  _editionName;
    public string  EditionName
    {
        get { return _editionName; }
        set { _editionName = value; }
    }

    private string  _editionDescription;
    public string  EditionDescription
    {
        get { return _editionDescription; }
        set { _editionDescription = value; }
    }

}

