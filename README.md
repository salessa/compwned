# compwned
(Compact PWNED)

## Introduction

Troy Hunt has a service called ["Pwned Passwords"](https://haveibeenpwned.com/Passwords) that provides a list of breached passwords (~320 million passwords so far). The SHA-1 hash of the leaked passwords is provided and can be downloaded or searched online. The aim is to assist users and online services to identify leaked passwords.  You can read about it [here](https://www.troyhunt.com/introducing-306-million-freely-downloadable-pwned-passwords/)

There are a couple of challenges that I am trying to address here:
1. It is not recommended that you reveal your password (or even its SHA-1 hash) to a third-party service. So that makes it hard to create an online app/service that does not require the user to give away their password.
2. The full breached password list (SHA-1 hashes) is ~13GB when uncompressed. This might make it challenging for some people to download and work with the list on their local machine.

So I have created a compact (**~550MB**) representation of the pwned passwords (a bloom filter essentially - see the "How it Works" section below). The file is currently hosted at: 
[https://umich.box.com/shared/static/711ty0od6koat9mzqtuzcs9g9mmz8kqq.bin](https://umich.box.com/shared/static/711ty0od6koat9mzqtuzcs9g9mmz8kqq.bin). If you check for a pwned password using this file, you will definitely find it. The catch is that if you search for a *non*-pwned password, there is a 0.1% chance the program will tell you it is pwned (i.e. an ~0.1% false positive). In short, if you cannot find your password in the compressed list, it means it is not is the original list of Pwned passwords.
(Look at the bottom of this README for additional download locations and checksum).

This repository contains a sample Python program/library that lets you search through this bloom filter without sending your password (or its hash) to the remote server. And you do not have to download the large file to your machine! Checking for a single password requires you to access only 10 bytes of data on the remote server. You can optionally download the full bloom filter to your local machine and use this Python program/library to search through it.

## Example Usage
Currently I only provide a python implementation for searching through this file. There are two ways to use this it:

**1. Searching through a remote file (without downloading file):**
(this does not transmit your passwords to the remote server - see "How it Works" below)

`./check_pass.py remote [url_of_bloom_filter]`    
(you will then be prompted to enter the password you want to search)

To use one of the files I am currently hosting, simply do:

`./check_pass.py remote "https://umich.box.com/shared/static/711ty0od6koat9mzqtuzcs9g9mmz8kqq.bin"`

(you will then be prompted to enter the password you want to search)

Optionally you can supply the password as a command line parameter:

`./check_pass.py remote "https://umich.box.com/shared/static/711ty0od6koat9mzqtuzcs9g9mmz8kqq.bin" [password]`

**2. Searching through a local file:**
First, download the file to your local machine. Then, simply run:

`./check_pass.py local [path_to_file]` 

(you will then be prompted to enter the password you want to search)

or

`./check_pass.py local [path_to_file] [password]` 

## How it Works
As mentioned earlier, the password list is stored in a bloom filter. This [link](https://llimllib.github.io/bloomfilter-tutorial/) provides a good description of bloom filters. While there are more compact alternatives to the basic bloom filter implementation, I have decided to stick with the basic one to keep things simple.

The file that is provided has 46,15,205,609 bits and requires 10 independent SHA-1 hash computations to index into it (and hence the file name "hibp_4615205609_10.bin"). With this setup, the theoretical false positive probability is 0.1%.

#### Searching the Remote File
The HTTP protocol allows clients to request a small portion of a file on the server (provided that the server properly supports the "Range" HTTP request header).
To search the bloom filter without downloading the full file, the program requests the HTTP server for the specific bits it wants to probe. Checking a single password in the current implementation requires only 10 bytes or less to be downloaded from the remote server (1 byte per hash function). 

**Note, however, an attacker can still see what portions of a file you are accessing. So if you have a hit in the bloom filter, a determined attacker might be able to use the information to narrow down their search**.  
You can send numerous fake requests to the server if you really want to hide your full access pattern (I plan to provide this implementation over the next few weeks).

## Using and Sharing the Code and Data File
Feel free to copy, modify, or share both the code and the bloom filter file (see LICENSE file). However, keep the following things in mind: 
1. This is a first iteration and there might be bug fixes and improvements that appear in this repository over the next few weeks.
2. I am currently not setup to handle a large volume of concurrent requests. So please avoid setting up an application that will send large amounts of requests the the file I am hosting (please download the file if you need to do that)

Here are two different links to download the bloom filter from:

http://www-personal.umich.edu/~salessaf/hibp_4615205609_10.bin

https://umich.box.com/shared/static/711ty0od6koat9mzqtuzcs9g9mmz8kqq.bin


(SHA-1 checksum: 46399228026c257bab80d947c17890a725b39afc)



## TODO

- Enable searching from inside a browser using a JavaScript implementation
- Provide slightly larger files with smaller false positive rates

===============

Salessawi Ferede Yitbarek
