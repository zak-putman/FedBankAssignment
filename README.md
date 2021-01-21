# Project Title

This is the project assignment for a position at the Federal Reserve Bank in Cleveland.

What this does is reads in a directory of files and will parse through them and remove the following:
- Stop words (list of words provided in a file)
- Non Alphabetical characters

After the removal of specified objects (see list above) it will then use a stemming algorithm to reduce all remaining words into their base form (See Contributing).
Once that is complete it will count the usages of the remaining words and print out the top 20 used words.

Assumptions Made:
- Ignored case on the stop words
- Whitespace is non alphabetical (Saved words on new line still easy to read)
- Outputs are saved in (workingdirectory)\TextFolder\Outputs

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

Computer and access to internet to pull the repository.

### Installing

Once repository is pulled there is a .zip folder labeled "Project Build".
Exact all in the zip to current directory.
In the unzipped folder is an .exe labeled "TextReader" double click and watch the magic happen.

-Note:GitHub gave me quite a bit of trouble with some commits, I think mainly due to creating a user and trying to push right of the rip. (I use bitbucket mostly)

## Contributing

Used stemming algorithm provided from https://tartarus.org/martin/PorterStemmer/csharp2.txt

## Authors

* **Zachary Putman** *
