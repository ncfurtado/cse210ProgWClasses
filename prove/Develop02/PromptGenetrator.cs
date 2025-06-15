class PromptGenerator
{
    Random randomGenerator = new Random();
    public List<string> _prompts = ["How did you see the hand of the Lord in your life today?", "What was something you enjoyed today?", "What's one thing that made you smile today?"];

    public void SelectPrompt(List<string> _prompts)
    {
        int number = randomGenerator.Next(1, maxValue);

    }
}