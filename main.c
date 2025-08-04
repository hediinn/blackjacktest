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

typedef card deck[52] ;

typedef struct decks{
    card cards[52];
    size_t size;
    
} decks ;


void swap(card *restrict c1, card *restrict c2) {
        card s;
        s = *c1;
        *c1 = *c2;
        *c2 = s;
}
card draw(deck d) {
    card c = d[0];
    for(int i = 0;i<51;i++){
        d[i] = d[i+1];
    }
    return c;
}

void cutDeck(deck ccs){
    for(int i = 0;i<26;i++){
        //printf("card1: %s %s | card2: %s %s \n",ccs[i].name, ccs[i].suit,ccs[i+26].name, ccs[i+26].suit);
        swap(&ccs[i], &ccs[i+26]);
    }
}
void shuffle(deck ccs){
    for(int i = 0;i<52;i++){
        int ran = rand()%52;
        swap(&ccs[ran], &ccs[i]);
    }
}
void Diff_shuffle(deck ccs){
    deck cd;
    for(int i = 0;i<26;i++){
        int c1 = i;
        int c2 = i+26;
        cd[i*2] = ccs[c2];
        cd[(i*2)+1] = ccs[i];

    }
    for(int i = 0;i<52;i++){
        swap(&ccs[i], &cd[i]);
    }
}
void printDeck(deck ccs){
    card s;
    for (int i = 0; i<52; i++) {
        s = ccs[i]; 
        if(i % 2 == 0){
            printf("card name: %-5s of %-7s | val: %-2d ##", s.name, s.suit, s.num);
        }else{
            printf(" card name: %-5s of %-7s | val: %-2d \n", s.name, s.suit, s.num);
        }
    }
    printf("--------------------------------------------------------------\n");

}

int main() {

    srand(time(NULL));
    deck cs;
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
    //shuffle(cs);
    Diff_shuffle(cs);
    Diff_shuffle(cs);
    cutDeck(cs);
    shuffle(cs);
    printDeck(cs);
    //for (int i = 0; i<4; i++) {
    s = draw(cs); 
    printf("card name: %s of %s | val: %d \n", s.name, s.suit, s.num);
    //}   
    
    return 0;
}

