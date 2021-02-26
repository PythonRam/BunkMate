import sys
import requests

if __name__ == '__main__':
    ##link = sys.argv[2]
    ##url = sys.argv[1]
    ##USERNAME =sys.argv[3]
   
    ##PASSWORD = sys.argv[4]
    with requests.Session() as c:
         url="http://websismit.manipal.edu/sis/control/main"
         link = "http://websismit.manipal.edu/sis/control/ListCTPEnrollment?customTimePeriodId=MAY2015"
    
    
         c.get(url);
         login_data =dict(USERNAME="KLSRISOWMYA@3168149",PASSWORD="3168149")
         c.post(url,data=login_data)
         page1= c.get(link)
         got=page1.content
         string=got
    
    n=open("C:\Users\MAHE\Documents\Bunk Mate\Bunk Mate\RequestsForC#\data.txt","w+")
    n.write(string)
    n.close()






#-------------------------------------------------------------------------------





    

