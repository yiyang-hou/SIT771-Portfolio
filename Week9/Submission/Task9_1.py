class Account:
    def __init__(self, name, startingBalance):
        self.__name = name
        self.__balance = startingBalance

    def print_account(self):
        print("%s $%.2f" % (self.__name, self.__balance))
    
    @property
    def name(self):
      return self.__name
    
    def withdraw(self, amount):
      self.__balance -= amount

    def deposit(self, amount):
      self.__balance += amount



account = Account("Fred", 1000.0)
account.print_account()

another_account = Account("Jake", 10.0)
another_account.print_account()

num = 0
while num != 4:
  print("*****Menu*****")
  print("Select an option: ", "1. Deposit", "2. Withdraw", "3. Print Account", "4. Quit", sep="\n")
  line = input()
  num = int(line)
  if num == 1:
    print("How much do you want to deposit? Please Enter: ")
    amount = int(input())
    account.deposit(amount)
    account.print_account()

  if num == 2:
    print("How much do you want to withdraw? Please Enter: ")
    amount = int(input())
    account.withdraw(amount)
    account.print_account()

  if num == 3:
    account.print_account()
  
  if num == 4:
    print("Quit!")

