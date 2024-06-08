# Unexpected ways to use GitHub Copilot

- Write pull request summaries (Copilot Enterprise feature only)
- Generate commit messages
- Fix code inline
- Generate documentation for your code
- Meaningful names matter (VS Code <kbd>F2</kbd>)
- Create unit test
- Assist with debugging code
- Explaining code
- Documenting code

The following table was copied from [this page](https://github.blog/2024-03-25-how-to-use-github-copilot-in-your-ide-tips-tricks-and-best-practices/) in raw format then asked Copilot to create a three column markdown table :green_heart:

| Command | Description | Usage |
|---------|-------------|-------|
| /explain | Get code explanations | Open file with code or highlight code you want explained and type: /explain what is the fetchPrediction method? |
| /fix | Receive a proposed fix for the problems in the selected code | Highlight problematic code and type: /fix propose a fix for the problems in fetchAirports route |
| /tests | Generate unit tests for selected code | Open file with code or highlight code you want tests for and type: /tests |
| /help | Get help on using Copilot Chat | Type: /help what can you do? |
| /clear | Clear current conversation | Type: /clear |
| /doc | Add a documentation comment | Highlight code and type: /doc |
| /generate | Generate code to answer your question | Type: /generate code that validates a phone number |
| /optimize | Analyze and improve running time of the selected code | Highlight code and type: /optimize fetchPrediction method |
| /new | Scaffold code for a new workspace | Type: /new create a new django app |
| /simplify | Simplify the selected code | Highlight code and type: /simplify |
| /feedback | Provide feedback to the team | Type: /feedback |