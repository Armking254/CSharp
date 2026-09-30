#include <iostream>
#include <list>
using namespace std;

int main() {
    list<int> numbers = {10, 20, 30, 40};

    cout << "Original list: ";
    for (int value : numbers) {
        cout << value << " ";
    }
    cout << endl;

    numbers.push_front(5);
    numbers.push_back(50);

    cout << "After adding front and back: ";
    for (int value : numbers) {
        cout << value << " ";
    }
    cout << endl;

    numbers.pop_front();
    numbers.pop_back();

    cout << "After removing front and back: ";
    for (int value : numbers) {
        cout << value << " ";
    }
    cout << endl;

    cout << "Size of list: " << numbers.size() << endl;

    numbers.sort();
    cout << "Sorted list: ";
    for (int value : numbers) {
        cout << value << " ";
    }
    cout << endl;

    return 0;
}
