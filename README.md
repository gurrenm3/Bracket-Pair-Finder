# Bracket-Pair-Finder
A small class for quickly finding all bracket pairs in a string. Between 4-8x faster than manually checking for pairs. 

### How is it faster?
Instead of looping over the entire text searching for each matching pair, this class loops the text only once. It uses a Stack to keep track of all the currently unmatched pairs and matches them as they are found. This results in a significant performance boost over stopping to search for each pair. Most json files (up to a few thousand lines) are parsed in under 1ms vs 3-5ms with the long way. Enourmous 2million line json files are parsed in about 500-700ms, vs 4-6seconds with the long way
