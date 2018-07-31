//By: Zachary Hamid, z5059915
//Date: 6/06/2015
//Description: SNAKE!!!

#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <math.h>
#include <string.h>
#include <time.h>
#include <assert.h>

#define TRUE 1
#define FALSE 0

#define MAX_PLAYER_LENGTH 1500
#define MAX_APPLES 7
#define APPLE_SPAWN_TIME 60

#define TAIL_SIGN "~"
#define PLAYER_SIGN '@'

#define UPDATE_RATE 100000000

typedef struct _snake{
   int length;
   int score;
   int posX;
   int posY;
   char sign;
} snake;

typedef struct _level{
   int cols;
   int rows;
} level;

typedef struct _apple{
   char id[1];
   int posX;
   int posY;
   char sign;
} apple;

typedef struct _position{
   int x;
   int y;
} position;

typedef int boolean;

void update(snake* player, level theLevel, apple* appleArray, int* appleTimer, 
            int* timer, char* input, position positionArray[], boolean* running);
void draw(snake* player, level theLevel, apple* appleArray, position positionArray[]);
void removeApple(apple* appleArray, int index);

int main(int argc, char *argv[]){
   //Set up rand() function
   time_t t;

   srand((unsigned) time(&t));

   position positionArray[MAX_PLAYER_LENGTH];
   int updateTimer = 0;
   char input = ' ';
   int appleTimer = rand() % APPLE_SPAWN_TIME;
   int timer = 0;
   boolean running;
   running = TRUE; //When game starts, it's running!
   snake player;
   //ASSIGN PLAYER VALUES//////////
   player.length = 1; //Test values!
   player.score = 0; //Test values!
   player.posX = 1; //Test values!
   player.posY = 1; //Test values!
   player.sign = PLAYER_SIGN;
   ///////////////////////////////

   apple appleArray[MAX_APPLES];
   //Clear array
   int k = 0;
   while(k < MAX_APPLES){
      appleArray[k].id[0] = '\0';
      k++;
   }
   system("cls");
   level theLevel;
   printf("Level width: ");
   scanf("%d", &theLevel.cols);
   printf("Level height: ");
   scanf("%d", &theLevel.rows);

   while(running != FALSE){
      if(updateTimer >= UPDATE_RATE){
         update(&player, theLevel, appleArray, &appleTimer, &timer, &input, positionArray, &running);
         updateTimer = 0;
      }
      updateTimer++;
   }
   printf("GAME OVER! Your final score is: %d\n", player.score);
   return EXIT_SUCCESS;
}

//Maybe chuck this huge parameter into a struct called game?
void update(snake* player, level theLevel, apple* appleArray, int* appleTimer, 
            int* timer, char* input, position positionArray[], boolean* running){
   srand(time(NULL)); //Reseed random function every update
   //ADD APPLES TO ARRAY
   if(*timer >= *appleTimer){
      int i = 0;
      apple newApple;
      newApple.posX = rand() % (theLevel.cols - 2) + 1; //Randomise X position
                                                        //to inside the board
      if((newApple.posX <= 0) || (newApple.posX >= (theLevel.cols - 1))){
         newApple.posX = rand() % (theLevel.cols - 2) + 1;
      }
      newApple.posY = rand() % (theLevel.rows - 2) + 1; //Randomise Y position
                                                        //to inside the board

      if((newApple.posY <= 0) || (newApple.posY >= (theLevel.rows - 1))){
         newApple.posY = rand() % (theLevel.rows - 2) + 1;
      }
      newApple.sign = '*';
      *newApple.id = '1';
      while(appleArray[i].id[0] != '\0'){ //Keep checking apple array till empty entry
         if(i < (MAX_APPLES - 1)){
            i++;
         } else { //If there are no empty entries, overwrite the first entry
            i = 0;
            break;
         }
      }
      if((i >= 0) && (i < MAX_APPLES)){
         appleArray[i].posX = newApple.posX; //add new apple at that entry
         appleArray[i].posY = newApple.posY;
         appleArray[i].sign = newApple.sign;
         appleArray[i].id[0] = newApple.id[0];
      }
      *appleTimer = rand() % APPLE_SPAWN_TIME + 10;
      *timer = 0;
   }
   /////////////////////////////////////////////////////////

   if(kbhit()){ //kbhit() checks if the user has input a key
      char tempInput;
      tempInput = *input;
      *input = getch(); //Assigns this key to the variable input
      //All this complicated stuff is just so the player can't move back into themselves
      if(tempInput == 'a'){
         if(*input != 'd'){
         } else { 
            *input = tempInput;
         }
      } else if(tempInput == 'd'){
         if(*input != 'a'){
         } else { 
            *input = tempInput;
         }
      } else if(tempInput == 'w'){
         if(*input != 's'){
         } else { 
            *input = tempInput;
         }
      } else if(tempInput == 's'){
         if(*input != 'w'){
         } else { 
            *input = tempInput;
         }
      } else {
      }
      /////////////////////////////////////////////////////////////////////////////////
   }
   //MOVEMENT OF PLAYER
   if(*input == 'w'){
      player->posY--;
   } else if(*input == 'a'){
      player->posX--;
   } else if(*input == 's'){
      player->posY++;
   } else if(*input == 'd'){
      player->posX++;
   }
   //END MOVEMENT
   int i = 0;
   while((appleArray[i].id[0] != '\0') && (i < MAX_APPLES)){
      if((player->posX == appleArray[i].posX) && (player->posY == appleArray[i].posY)){
         int tempLength = player->length;
         removeApple(appleArray, i);
         player->score++;
         if((tempLength + 1) <= MAX_PLAYER_LENGTH){
            player->length = tempLength + 1;
         }
      }
      i++;
   }

   //BOUNDARIES FOR PLAYER
   if(player->posX >= (theLevel.cols - 1)){
      player->posX = 1;
   } else if(player->posX < 1){
      player->posX = theLevel.cols - 2;
   } else if(player->posY >= (theLevel.rows - 1)){
      player->posY = 1;
   } else if(player->posY < 1){
      player->posY = theLevel.rows - 2;
   }
   //END BOUNDARIES

   int k = 0;
   while (k < (player->length)){
      positionArray[(player->length) - k] = positionArray[((player->length) - k) - 1];
      k++;
   }

   k = 0;
   positionArray[0].x = player->posX;
   positionArray[0].y = player->posY;
   while(k < (player->length)){
      if(k > 0){
         if((player->posX == positionArray[k].x) && (player->posY == positionArray[k].y)){
            *running = FALSE; //GAME OVER IF YOU HIT YOURSELF
         }
      }
      k++;
   }
   draw(player, theLevel, appleArray, positionArray); //Draw the level out in each update
   (*timer)++;
}

void draw(snake* player, level theLevel, apple* appleArray, position positionArray[]){
   system("cls"); //Want to clear the screen every time the game is updated.
   printf("\n       Score: %d\n\n\n", player->score);
   int levelRow = 0;
   int levelCol = 0;
   int i = 0;
   int k = 0;
   boolean hasPrinted = FALSE;
   while(levelRow < theLevel.rows){
      while(levelCol < theLevel.cols){
         if(levelCol == 0){
            printf("#");
            hasPrinted = TRUE;
         } else if(levelCol == (theLevel.cols - 1)){
            printf("#");
            hasPrinted = TRUE;
         } else if((levelRow == 0) || (levelRow == (theLevel.rows - 1))){
            printf("#");
            hasPrinted = TRUE;
         } else if((player->posX == levelCol) && (player->posY == levelRow)){
            printf("%c", player->sign);
            hasPrinted = TRUE;
         }
         while(k < (player->length)){
            if((positionArray[k].x == levelCol) && (positionArray[k].y == levelRow)){
               if(k > 0){
                  printf(TAIL_SIGN);
                  hasPrinted = TRUE;
                  break;
               }
            }
            k++;
         }
         k = 0;
         while((appleArray[i].id[0] != '\0') && (i < MAX_APPLES)){ //Checks until there's an empty entry
            if((appleArray[i].posX == levelCol) && (appleArray[i].posY == levelRow)){
               if((player->posX == appleArray[i].posX) && (player->posY == appleArray[i].posY)){
               } else if(hasPrinted == FALSE) {
                  printf("%c", appleArray[i].sign);
                  hasPrinted = TRUE;
               }
               break;
            }
            i++;
         }
         i = 0;
         ///////////////////////////////////////////////////
         if(hasPrinted == FALSE){
            printf(" ");
         }
         hasPrinted = FALSE;
         levelCol++;
      }
      printf("\n");
      levelCol = 0;
      levelRow++;
   }
}

void removeApple(apple* appleArray, int index){
   apple newApple;
   if(index < MAX_APPLES){
      while((appleArray[index].id[0] != '\0') && (index < MAX_APPLES)){
         if(appleArray[index + 1].id[0] == '1'){
            newApple = appleArray[index + 1];
            appleArray[index] = newApple;
         } else {
            appleArray[index].id[0] = '\0';
         }
         index++;
      }
   } else {
      appleArray[index].id[0] = '\0';
   }
}