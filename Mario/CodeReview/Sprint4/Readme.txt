Warning Assert:
CA1822: It is better not add them as static, since I think add Item to the block should not be a golbal behavior.
So I think that is better not to be static. By instance is also okay.

CA1011: The reason we use Imario is to make the mario Damage runs well, So I think it is better not change to IPowerUpEvent
Behavoir, that will make lot of extra work.


CA1502:
The reason complexity more than 25 is because we test the collision based on the global test, so we are going to change 
them in futrue work. 

