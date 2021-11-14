/// <summary>
/// Finds all matching bracket pairs. 
/// </summary>
class BracketPairFinder
{
    /// <summary>
    /// The original text that the bracket pairs are from
    /// </summary>
    public readonly string originalText;

    /// <summary>
    /// The definition of what an Opening Bracket should be. Used to find the start of the pair.
    /// </summary>
    public readonly char openingBracket;

    /// <summary>
    /// The definition of what an Closing Bracket should be. Used to find the end of the pair.
    /// </summary>
    public readonly char closingBracket;

    /// <summary>
    /// A cache of all the found bracket pairs
    /// </summary>
    private Dictionary<int, int> bracketPairs;

    /// <summary>
    /// Initializes a new instance of the <see cref="BracketPairFinder"/> class, which is used to find all bracket pairs in a string of text.
    /// </summary>
    /// <param name="text">Text to search for bracket pairs</param>
    /// <param name="openingBracket">Definition of what the Opening Bracket should be for each pair</param>
    /// <param name="closingBracket">Definition of what the Closing Bracket should be for each pair</param>
    public BracketPairFinder(string text, char openingBracket, char closingBracket)
    {
        this.originalText = text;
        this.openingBracket = openingBracket;
        this.closingBracket = closingBracket;
    }

    /// <summary>
    /// Gets all of the Bracket Pairs in this text. Results are cached to improve performance on future calls to this method.
    /// </summary>
    /// <returns>Upon completing this method will return all of the bracket pairs in this text</returns>
    public async Task<Dictionary<int,int>> GetBracketPairsAsync()
    {
        return await Task.Factory.StartNew(() => GetBracketPairs());
    }

    /// <summary>
    /// Gets all of the Bracket Pairs in this text. Results are cached to improve performance on future calls to this method.
    /// </summary>
    /// <returns>Upon completing this method will return all of the bracket pairs in this text</returns>
    public Dictionary<int, int> GetBracketPairs()
    {
        if (bracketPairs != null)
            return bracketPairs;

        bracketPairs = new Dictionary<int, int>();
        var unsetBracketKeys = new Stack<int>(); // used to keep track of all unset bracket pairs, in order of most recent unset pair to oldest.
        for (int i = 0; i < originalText.Length; i++)
        {
            if (originalText[i] == openingBracket)
            {
                bracketPairs.Add(i, -1); // assigning -1 to the closing bracket index to help identify errors
                unsetBracketKeys.Push(i);
                continue;
            }

            if (originalText[i] == closingBracket)
            {
                if (!unsetBracketKeys.TryPop(out int key))
                    continue;

                bracketPairs[key] = i;
            }
        }
        return bracketPairs;
    }
}
