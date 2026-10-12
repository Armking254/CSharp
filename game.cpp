
#include <iostream>
#include <cstdlib>
#include <ctime>
#include <string>
#include <limits>

using namespace std;

int main() {
    srand(static_cast<unsigned int>(time(nullptr)));

    string playerName;
    int choice;

    cout << "\n";
    cout << "=====================================\n";
    cout << "       WELCOME TO C++ GAME ZONE      \n";
    cout << "=====================================\n";

    cout << "\nEnter your name: ";
    getline(cin, playerName);

    cout << "\nHello, " << playerName << "! Welcome!\n";

    do {
        cout << "\n========== MAIN MENU ==========\n";
        cout << "1. Play Number Guessing Game\n";
        cout << "2. View Game Rules\n";
        cout << "3. Exit\n";
        cout << "Choose an option: ";

        if (!(cin >> choice)) {
            cout << "\nInvalid input! Please enter a number.\n";
            cin.clear();
            cin.ignore(numeric_limits<streamsize>::max(), '\n');
            choice = 0;
            continue;
        }

        if (choice == 1) {
            int secretNumber = rand() % 100 + 1;
            int guess;
            int attempts = 0;
            const int maxAttempts = 7;
            bool won = false;

            cout << "\n=====================================\n";
            cout << "         NUMBER GUESSING GAME        \n";
            cout << "=====================================\n";
            cout << "I have chosen a number from 1 to 100.\n";
            cout << "You have " << maxAttempts << " attempts!\n";

            while (attempts < maxAttempts) {
                cout << "\nAttempt " << attempts + 1
                     << "/" << maxAttempts << ": Enter your guess: ";

                if (!(cin >> guess)) {
                    cout << "Please enter a valid whole number!\n";
                    cin.clear();
                    cin.ignore(numeric_limits<streamsize>::max(), '\n');
                    continue;
                }

                if (guess < 1 || guess > 100) {
                    cout << "Your guess must be between 1 and 100.\n";
                    continue;
                }

                attempts++;

                if (guess == secretNumber) {
                    won = true;
                    int score = (maxAttempts - attempts + 1) * 100;

                    cout << "\n*** CONGRATULATIONS, "
                         << playerName << "! ***\n";
                    cout << "You guessed the secret number!\n";
                    cout << "Attempts used: " << attempts << "\n";
                    cout << "Your score: " << score << " points!\n";
                    break;
                } else if (guess < secretNumber) {
                    cout << "Too LOW! Try a higher number.\n";
                } else {
                    cout << "Too HIGH! Try a lower number.\n";
                }

                if (attempts < maxAttempts) {
                    int difference = abs(secretNumber - guess);

                    if (difference <= 5) {
                        cout << "Hint: You are VERY close!\n";
                    } else if (difference <= 15) {
                        cout << "Hint: You are getting warm!\n";
                    } else {
                        cout << "Hint: You are still far away!\n";
                    }
                }
            }

            if (!won) {
                cout << "\nGAME OVER! Better luck next time.\n";
                cout << "The secret number was: "
                     << secretNumber << "\n";
            }

        } else if (choice == 2) {
            cout << "\n========== GAME RULES ==========\n";
            cout << "1. Guess a secret number from 1 to 100.\n";
            cout << "2. You have seven valid attempts.\n";
            cout << "3. The game tells you if your guess is too high or low.\n";
            cout << "4. Extra hints tell you how close you are.\n";
            cout << "5. The fewer attempts you use, the higher your score.\n";

        } else if (choice == 3) {
            cout << "\nThank you for playing, " << playerName << "!\n";
            cout << "Keep learning C++ and keep coding!\n";

        } else {
            cout << "\nInvalid option! Choose 1, 2, or 3.\n";
        }

    } while (choice != 3);

    cout << "\nProgram closed successfully.\n";
    return 0;
}