#define __STDC_LIMIT_MACROS
#define NOMINMAX
#include <iostream>
#include <sstream>
#include <iterator>
#include <stdlib.h>
#include <stdio.h>
#include <stdint.h>
#include <string>
#include <thread>
#include <conio.h>
#include <vector>
#include <Windows.h>

/*
	To do:
		- Need a way to store everything currently printed to the screen
		- If console window is resized, the text should be too (bounding box)
		- https://stackoverflow.com/questions/23369503/get-size-of-terminal-window-rows-columns
*/

#define TYPE_SPEED 40		// Lower is faster

// IF USING THE "\" CHARACTER, USE 2 "\" CHARACTERS INSTEAD TO ESCAPE THE BACKSLASH
#define OPTION_BOX "/-\\|>|+-+\\-/"
#define OPTION_BOX_MAX_LENGTH 50

//Keys
#define ENTER_KEY 0xD
#define LEFT_ARROW_KEY 0x4B
#define UP_ARROW_KEY 0x48
#define DOWN_ARROW_KEY 0x50
#define RIGHT_ARROW_KEY 0x4D

using namespace std;

void type_text(const string& s);
void story_text(const string& s);
void clear_text(void);
void refresh_console(void);
void clear_input(void);
void wait_for_enter(void);
int display_option_box(vector<string>);

vector<string> split(const string&, char);
string join(const vector<string>&, const char*);
string replaceStringInPlace(const string&, const string&, const string&);

// Maybe change to stringstream instead
string _console_text;

// Types text character by character, if enter is pressed (ON WINDOWS), completes the string instantly
void type_text(const string& text) {
	string t = replaceStringInPlace(text, "{player-name}", p.getName());
	for (int i = 0; i < t.size(); i++) {
		cout << t[i] << flush;
		_console_text.push_back(t[i]);
		this_thread::sleep_for(chrono::milliseconds(TYPE_SPEED));
		if (_kbhit()) {
			if (_getch() == ENTER_KEY) {
				if (i < t.size() - 1) {
					int index = t.size() - i - 1;
					cout << t.substr(i + 1, index) << flush;
					_console_text.append(t.substr(i + 1, index));
					break;
				}
			}
		}
	}
}

// Requires that you press enter after string is finished to continue
void story_text(const string& text) {
	type_text(text);
	wait_for_enter();
}

// Waits for enter key to be pressed (ON WINDOWS)
void wait_for_enter() {
	while (!_kbhit() && !(_getch() == ENTER_KEY)) {}
}

// Clears the console
void clear_text() {
	system("cls");
	_console_text = "";
}

void refresh_console() {
	system("cls");
	cout << _console_text;
}

// Clears the input buffer
void clear_input() {
	cin.clear();
	cin.ignore(std::numeric_limits<streamsize>::max(), '\n');
}

string name_input() {
	bool decided = false;
	string name;
	do {
		cout << "Enter name: ";
		cin >> name;
		clear_input();
		p.setName(name);
		type_text("???: {player-name}? Is this correct? [y]es or [n]o?\n");
		do {
			cout << "> ";
			char ans;
			cin >> ans;
			clear_input();
			if (ans == 'y' || ans == 'Y') decided = true;
			else if (ans == 'n' || ans == 'N') break;
			else type_text("You must type [y]es or [n]o.\n");
		} while (!decided);
	} while (!decided);
	return name;
}

int display_option_box(vector<string> options) {
	bool enterPressed = false;
	int option_box_num_lines = 0;
	int current_selection = 0;
	int max_string_len = 0;
	for (vector<string>::iterator it = options.begin(); it != options.end(); ++it) {
		(*it) = replaceStringInPlace((*it), "\n", "");
		// Get max length string
		if (it->length() > max_string_len) {
			max_string_len = it->length();
		}
	}

	// Get the width of the option box to be used
	int option_box_length;
	if ((max_string_len + 6) > OPTION_BOX_MAX_LENGTH) option_box_length = OPTION_BOX_MAX_LENGTH;
	else option_box_length = max_string_len + 6;

	string box_design = OPTION_BOX;

	do {
		// Print out top of box
		cout << box_design.at(0);
		_console_text.push_back(box_design.at(0));
		for (int i = 0; i < (option_box_length - 2); i++) {
			cout << box_design.at(1);
			_console_text.push_back(box_design.at(1));
		}
		cout << box_design.at(2) << endl;
		_console_text.push_back(box_design.at(2));
		_console_text.push_back('\n');

		option_box_num_lines++;

		int index = 0;
		for (vector<string>::iterator it = options.begin(); it != options.end(); ++it) {

			if ((it->length() + 6) > option_box_length) {
				for (int i = 0; i < it->length(); i += (option_box_length - 6)) {

					cout << box_design.at(3);
					_console_text.push_back(box_design.at(3));
					string s = it->substr(i, (option_box_length - 6));
					cout << " ";
					_console_text.push_back(' ');
					if (index == current_selection && i == 0) {
						cout << box_design.at(4);
						_console_text.push_back(box_design.at(4));
					}
					else {
						cout << " ";
						_console_text.push_back(' ');
					}
					cout << " " << s;
					_console_text.push_back(' ');
					_console_text.append(s);

					// Print filler spaces at end of text
					if ((s.length() + 6) <= option_box_length) {
						for (int i = 0; i < (option_box_length - (s.length() + 6)); i++) {
							cout << " ";
							_console_text.push_back(' ');
						}
					}
					cout << " " << box_design.at(5) << endl;
					_console_text.push_back(' ');
					_console_text.push_back(box_design.at(5));
					_console_text.push_back('\n');
					option_box_num_lines++;
				}
			}
			else {
				cout << box_design.at(3);
				_console_text.push_back(box_design.at(3));
				cout << " ";
				_console_text.push_back(' ');
				if (index == current_selection) {
					cout << box_design.at(4);
					_console_text.push_back(box_design.at(4));
				}
				else {
					cout << " ";
					_console_text.push_back(' ');
				}
				cout << " " << (*it);
				_console_text.push_back(' ');
				_console_text.append((*it));

				// Print filler spaces at end for options that are not big enough to fill the box
				if ((it->length() + 6) <= option_box_length) {
					for (int i = 0; i < (option_box_length - (it->length() + 6)); i++) {
						cout << " ";
						_console_text.push_back(' ');
					}
				}
				cout << " " << box_design.at(5) << endl;
				_console_text.push_back(' ');
				_console_text.push_back(box_design.at(5));
				_console_text.push_back('\n');
				option_box_num_lines++;
			}


			// Print inter-option divider line
			vector<string>::iterator temp = it;
			if (++temp != options.end()) {
				cout << box_design.at(6);
				_console_text.push_back(box_design.at(6));
				for (int i = 0; i < (option_box_length - 2); i++) {
					cout << box_design.at(7);
					_console_text.push_back(box_design.at(7));
				}
				cout << box_design.at(8) << endl;
				_console_text.push_back(box_design.at(8));
				_console_text.push_back('\n');
				option_box_num_lines++;
			}
			index++;
		}

		//Print out bottom of box
		cout << box_design.at(9);
		_console_text.push_back(box_design.at(9));
		for (int i = 0; i < (option_box_length - 2); i++) {
			cout << box_design.at(10);
			_console_text.push_back(box_design.at(10));
		}
		cout << box_design.at(11) << endl;
		_console_text.push_back(box_design.at(11));
		_console_text.push_back('\n');
		option_box_num_lines++;

		//Returns the chosen option
		while (!_kbhit());
		if (_kbhit()) {
			vector<string> lines; string s;
			switch (_getch()) {
			case UP_ARROW_KEY:
				if (current_selection != 0) current_selection--;
				//REFRESH DIALOGUE BOX
				lines = split(_console_text, '\n');
				lines.erase(lines.end() - option_box_num_lines, lines.end());
				_console_text = join(lines, "\n");
				refresh_console();
				break;
			case DOWN_ARROW_KEY:
				if (current_selection < (options.size() - 1)) current_selection++;
				// REFRESH DIALOGUE BOX
				lines = split(_console_text, '\n');
				lines.erase(lines.end() - option_box_num_lines, lines.end());
				_console_text = join(lines, "\n");
				refresh_console();
				break;
			case ENTER_KEY:
				enterPressed = true;
				break;
			default:
				break;
			}
		}
		option_box_num_lines = 0;
	} while (!enterPressed);
	return current_selection;
}

string replaceStringInPlace(const string& subject, const string& search, const string& replace) {
	size_t pos = 0;
	string s = subject;
	while ((pos = s.find(search, pos)) != std::string::npos) {
		s.replace(pos, search.length(), replace);
		pos += replace.length();
	}
	return s;
}


vector<string> split(const string &s, char delim) {
	stringstream ss(s);
	string item;
	vector<string> tokens;
	while (getline(ss, item, delim)) {
		tokens.push_back(item);
	}
	return tokens;
}

string join(const vector<string>& vec, const char* delim)
{
	stringstream res;
	copy(vec.begin(), vec.end(), ostream_iterator<string>(res, delim));
	return res.str();
}