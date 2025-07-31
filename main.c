#include <stddef.h>
#include <stdio.h>
#include <time.h>
#include <stdlib.h>


char* names[13] = {
   "ace"    ,
   "two"    ,
   "tre"    ,
   "four"   ,
   "five"   ,
   "six"    ,
   "seven"  ,
   "ate"    ,
   "nine"   ,
   "ten"    ,
   "jack"   ,
   "queen"  ,
   "king"
};
char* suits[4] = {
   "Spade", 	
   "Heart",
   "Diamond",
   "Club"
};

typedef struct card{
    int num;
    char *name;
    char *suit;
} card ;

typedef card cards[52] ;

void swap(card *restrict c1, card *restrict c2) {
        card s;
        s = *c1;
        *c1 = *c2;
        *c2 = s;


}
void shuffle(cards ccs){
    for(int i = 0;i<52;i++){
        int ran = rand()%52;
        swap(&ccs[ran], &ccs[i]);

    }
   
}

void printDeck(cards ccs){
    card s;
    for (int i = 0; i<52; i++) {
        s = ccs[i]; 
        printf("card name: %s of %s | val: %d \n", s.name, s.suit, s.num);
    }

}

int main() {

    srand(time(NULL));
    cards cs;
    card c;
    int d = 0;
    for(int j = 0; j<4;j++){
        int i = 0;
        for (i = 0; i<13; i++) {
            c.suit = suits[j];
            c.name = names[i];
            if(i >9){
                c.num = 10;
            }else{
                c.num = i+1;
            }
            cs[d] = c;
            d++;
        }
    }
    card s;
    for (int i = 0; i<3; i++) {
        s = cs[i]; 
        printf("card name: %s of %s | val: %d \n", s.name, s.suit, s.num);
    } 
    shuffle(cs);
    shuffle(cs);
    shuffle(cs);
    for (int i = 0; i<3; i++) {
        s = cs[i]; 
        printf("card name: %s of %s | val: %d \n", s.name, s.suit, s.num);
    }   
    
    return 0;
}

