using System.ComponentModel.DataAnnotations;

public class Account
{
    private List<int> _transactions = new List<int>();
    private int _balance = int.MinValue;

    public void Deposit(int amount)
    {
        _transactions.Add(amount);
        _balance = int.MinValue;
    }

    public int GetBalance()
    {
        if (_balance == int.MinValue)
        {
            int runningBalance = 0;
            {
                foreach (int amount in _transactions)
                {
                    runningBalance += amount;
                }
                _balance = runningBalance;
            }
        }
        return _balance;
    }
}