

This work is to confirm 

a) if two instance of reader (client) reads from a eventhub that uses a default consumer group, then it will crash
Crash here means, the first client will possibil terminate


b) you should create a new consumer group and get another instance to read from it. SO if you have 2 consumer group, 2 different instance 
readng from it will be fine. 

In other words, i can get 2 client to read from the same consumer group. 

