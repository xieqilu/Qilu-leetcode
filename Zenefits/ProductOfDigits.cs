static string getXNumber(int n) {
        string res = "";
        for(int i=9;i>1;i--){
            while(n%i==0){
                n/=i;
                res = i.ToString()+res;
            }
        }
        if(n!=1) 
            return "-1";
        return res;
    }
