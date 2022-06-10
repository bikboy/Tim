lst1 = [11,21,31,000]
for i in lst1:
  number = list(str(i))
  if(sum([int(x) for x in number]) == 0):
      print("right answer is ", number)
