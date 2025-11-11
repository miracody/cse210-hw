using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        // TODO: Split text and create Word objects
    }

    public void HideRandomWords()
    {
        // TODO: Hide random words
    }

    public string GetDisplayText()
    {
        return ""; // placeholder
    }

    public bool IsCompletelyHidden()
    {
        return false; // placeholder
    }
}
