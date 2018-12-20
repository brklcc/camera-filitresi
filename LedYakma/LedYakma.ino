int led1 = 2;
int led2 =3;
int led3 =4;
int led4 =5;
int led5 =6;
int led6 =7;
int led7 =8;
int led8 =9;
int led9 =10;
int gelenVeri;

void setup() {              
  pinMode(led1, OUTPUT);
  pinMode(led2, OUTPUT);
  pinMode(led3, OUTPUT);
  pinMode(led4, OUTPUT);
  pinMode(led5, OUTPUT);
  pinMode(led6, OUTPUT);
  pinMode(led7, OUTPUT);
  pinMode(led8, OUTPUT);
  pinMode(led9, OUTPUT);
  Serial.begin(9600);  
}

void loop() {
  if(Serial.available()){
    gelenVeri=Serial.read();
    if(gelenVeri=='1'){
      
      //led1 yak
      digitalWrite(led1, LOW);
      //söndür
      digitalWrite(led2, HIGH);
      digitalWrite(led3, HIGH);
      digitalWrite(led4, HIGH);
      digitalWrite(led5, HIGH);
      digitalWrite(led6, HIGH);
      digitalWrite(led7, HIGH);
      digitalWrite(led8, HIGH);
      digitalWrite(led9, HIGH);
     
    }
    
    if(gelenVeri=='2'){
      //YAK
      digitalWrite(led2, LOW);
      //SÖNDÜR
      digitalWrite(led1, HIGH);
      digitalWrite(led3, HIGH);
      digitalWrite(led4, HIGH);
      digitalWrite(led5, HIGH);
      digitalWrite(led6, HIGH);
      digitalWrite(led7, HIGH);
      digitalWrite(led8, HIGH);
      digitalWrite(led9, HIGH);
    } 

    if(gelenVeri=='3'){
      //YAK
      digitalWrite(led3, LOW);
      //SÖNDÜR
      digitalWrite(led2, HIGH);
      digitalWrite(led1, HIGH);
      digitalWrite(led4, HIGH);
      digitalWrite(led5, HIGH);
      digitalWrite(led6, HIGH);
      digitalWrite(led7, HIGH);
      digitalWrite(led8, HIGH);
      digitalWrite(led9, HIGH);
    }

    if(gelenVeri=='4'){
      digitalWrite(led4, LOW);
      //SÖNDÜR
      digitalWrite(led2, HIGH);
      digitalWrite(led3, HIGH);
      digitalWrite(led1, HIGH);
      digitalWrite(led5, HIGH);
      digitalWrite(led6, HIGH);
      digitalWrite(led7, HIGH);
      digitalWrite(led8, HIGH);
      digitalWrite(led9, HIGH);
    }

    if(gelenVeri=='5'){
      digitalWrite(led5, LOW);
       //SÖNDÜR
      digitalWrite(led2, HIGH);
      digitalWrite(led3, HIGH);
      digitalWrite(led4, HIGH);
      digitalWrite(led1, HIGH);
      digitalWrite(led6, HIGH);
      digitalWrite(led7, HIGH);
      digitalWrite(led8, HIGH);
      digitalWrite(led9, HIGH);
    }

    if(gelenVeri=='6'){
      digitalWrite(led6, LOW);
       //SÖNDÜR
      digitalWrite(led2, HIGH);
      digitalWrite(led3, HIGH);
      digitalWrite(led4, HIGH);
      digitalWrite(led5, HIGH);
      digitalWrite(led1, HIGH);
      digitalWrite(led7, HIGH);
      digitalWrite(led8, HIGH);
      digitalWrite(led9, HIGH);
    }

    if(gelenVeri=='7'){
      digitalWrite(led7, LOW);
       //SÖNDÜR
      digitalWrite(led2, HIGH);
      digitalWrite(led3, HIGH);
      digitalWrite(led4, HIGH);
      digitalWrite(led5, HIGH);
      digitalWrite(led6, HIGH);
      digitalWrite(led1, HIGH);
      digitalWrite(led8, HIGH);
      digitalWrite(led9, HIGH);
    }

    if(gelenVeri=='8'){
      digitalWrite(led8, LOW);
       //SÖNDÜR
      digitalWrite(led2, HIGH);
      digitalWrite(led3, HIGH);
      digitalWrite(led4, HIGH);
      digitalWrite(led5, HIGH);
      digitalWrite(led6, HIGH);
      digitalWrite(led7, HIGH);
      digitalWrite(led1, HIGH);
      digitalWrite(led9, HIGH);
    }

    if(gelenVeri=='9'){
      digitalWrite(led9, LOW);
       //SÖNDÜR
      digitalWrite(led2, HIGH);
      digitalWrite(led3, HIGH);
      digitalWrite(led4, HIGH);
      digitalWrite(led5, HIGH);
      digitalWrite(led6, HIGH);
      digitalWrite(led7, HIGH);
      digitalWrite(led8, HIGH);
      digitalWrite(led1, HIGH);
    }
    
   
  }
}
