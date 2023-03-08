var countBits = function(n) {
    let sum=0;    
    for(let i=0; i<40; i++){     
        //  console.log(n);   
      if(n>2){
        if(n%2==1)
        {
            sum++;  
            n-=1;                      
        }      
        // console.log(n); 
      }
      n=Math.round(n/2);      
    }
    return sum;
  };
 console.log(countBits(123334));