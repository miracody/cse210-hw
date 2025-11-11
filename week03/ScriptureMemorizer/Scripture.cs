using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
  private Reference _reference;
  private List<Word> _words;

  public Scripture(Reference reference, string text)
  {
    _reference = reference;
    _words = text.Split(" ").Select(word => new Word(word)).ToList();
  }

  public void HideRandomWords(int numberToHide)
  {
    Random rand = new Random();
    int hiddenCount = 0;

    
    List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();

    while (hiddenCount < numberToHide && visibleWords.Count > 0)
    {
      int index = rand.Next(visibleWords.Count);
      visibleWords[index].Hide();
      visibleWords.RemoveAt(index);
      hiddenCount++;
    }
  }

  public string GetDisplayText()
  {
    string text = string.Join(" ", _words.Select(w => w.GetDisplayText()));
    return $"{_reference.GetDisplayText()} - {text}";
  }

  public bool IsCompletelyHidden()
  {
    return _words.All(w => w.IsHidden());
  }
}