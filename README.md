# Bracket-Pair-Finder
A small class for quickly finding all bracket pairs in a string. Between 4-8x faster than manually checking for each pairs. 

### How is it faster?
Instead of looping over the entire text multiple times searching for each matching pair, this class loops the text only once. It uses a Stack to keep track of all the currently unmatched pairs and matches them as they are found. This results in a significant performance boost over searching for each pair one at a time. During testing with a Stopwatch, most json files (up to a few thousand lines) were parsed in between 0.5 and 1ms vs the long way, which on average took between ~3-5ms. Enormous 2million line json files were parsed in about 500-700ms, vs 4-6seconds with the long way
