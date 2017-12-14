# Mang
Mang is "moddable" WPF app that uses Markov chains to generate a list of names. It's intended to be used for anyone from fantasy writers to D&D players who just want a name for an NPC.

It is "moddable" in the sense that you, the user, can extend the input simply by creating a folder on your file system and dropping a text file (or any number of text files) containing names, and the app will automatically add that folder to the dropdown menu options so you can start generating names from your own input. Or, you can just paste your input directly into the window, and the app will generate output from that text.
## Installation
Download the source and compile.
## Usage
### To Run:
Open the project in your IDE of choice and build / compile / run.

An installer may be coming shortly.

### To Generate Names
Mang parses through the folders and files found in the `Names` folder and uses the names of the folders to populate the dropdown menu items. Inside the lowest-level named folder is at least one text file (or could be several text files -- up to you!). Mang uses the contents of these text files to generate names.

To add more dropdown menu items, simply make a new folder at the desired hierarchy level (explained below), then add a text file with enough contents to sensibly generate words from. For best results, it's recommended the file contains 100 items or more.

You don't have to create multiple folders with names, either. You should be able to add a single top-level folder, name it, and select it as the top-most dropdown item, then you'll be able to generate names from there.

Here are the buttons and what they mean / do:
* __Source__: The regional "source" of the name types. This is the broadest separation of types that makes sense. Notice that a "region" doesn't necessarily mean a physical area; there is a Fantasy region by default.
* __Type__: A sub-region; typically a sub-culture or culture within the top-level region. Or, different Fantasy worlds.
* __Sub-Type__: Usually refers to male, female, God, Orc, Dwarf, etc.

## Credits
Special thanks to:  
Kate Monk's Onomastikon, a wonderful compilation of names from all around the world. In Mang, many Medieval, Ancient World, and Aztec name sources were derived from this source, as well as the general layout of the menu structure. Please give this site a look.  

https://tekeli.li/onomastikon/index.html

donjon, which inspired me to make this tool.

https://donjon.bin.sh/

Icon by Freepik  
http://www.flaticon.com/authors/freepik  
Icon license Creative Commons BY 3.0  