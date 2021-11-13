/// <summary>
/// Finds all matching bracket pairs. 
/// </summary>
class BracketPairFinder
{
    private Dictionary<int, int> bracketPairs = new Dictionary<int, int>();
    private Stack<int> unsetBracketKeys = new Stack<int>();
    private string text;
    private char openingBracket;
    private char closingBracket;

    public BracketPairFinder(string text, char openingBracket, char closingBracket)
    {
        this.text = text;
        this.openingBracket = openingBracket;
        this.closingBracket = closingBracket;
        SetAllBracketPairs();
    }

    private void SetAllBracketPairs()
    {
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == openingBracket)
            {
                bracketPairs.Add(i, -1);
                unsetBracketKeys.Push(i);
                continue;
            }

            if (text[i] == closingBracket)
            {
                if (!unsetBracketKeys.TryPop(out int key))
                    continue;

                bracketPairs[key] = i;
            }
        }
    }

    /// <summary>
    /// Returns a copy of all the bracket pairs.
    /// </summary>
    /// <returns></returns>
    public Dictionary<int, int> GetBracketPairs()
    {
        var pairs = new Dictionary<int, int>();
        for (int i = 0; i < bracketPairs.Count; i++)
            pairs.Add(bracketPairs.Keys.ElementAt(i), bracketPairs.Values.ElementAt(i));

        return pairs;
    }
}
