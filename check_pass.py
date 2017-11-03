#!/usr/bin/env python

import hashlib
import mmap
import sys
import getpass
import urllib2
from optparse import OptionParser

DEBUG = False

NUM_HASHES = 10 
BIT_ARRAY_SIZE = 4615205609 
P_FALSE_POSITIVE = 0.001


_local_file = ""
_remote_url = ""
_mmaped_file = None


def _check_bit(offset, byte_val):
    #get bit array for the byte
    #and discard the '0b' at the beginning
    bit_str = bin ( ord(byte_val) )[2:] 
    
    #ensure everything is 8 bits long
    bit_str = bit_str.zfill(8)

    #we now extract the specific bit we want
    bit_index = offset % 8

    return bit_str[bit_index] == '1'


def _check_remote(offset):
    global _remote_url
    
    req = urllib2.Request(_remote_url)

    byte_index = offset/8
    req.add_header('Range', 'bytes=' + str(byte_index) + '-' + str(byte_index))    
    resp = urllib2.urlopen(req)
    byte_val = resp.read()

    found = _check_bit(offset, byte_val)
    
    if DEBUG: print ord(byte_val) , found
    
    return found

def _check_local(offset):
    
    global _local_file

    f = open(_local_file, "r+b")
    _mmaped_file =  mmap.mmap(f.fileno(), 0)

    #each bit in the bloom filter packed into a series of bytes.
    #we first need to read the byte that contains the bit we are interested in
    byte_index = offset/8
    byte_val = _mmaped_file[byte_index]
    
    found = _check_bit(offset, byte_val)

    if DEBUG: print ord(byte_val) , found

    f.close()

    return found

    
def pwned(password, search_remote=False):

    found = True

    if search_remote:
        checker = _check_remote
    else:
        checker = _check_local

    pass_hash = hashlib.sha1(password).hexdigest().upper()
    if DEBUG: print pass_hash
    int_hash = int( pass_hash, 16) % BIT_ARRAY_SIZE

    found = found & checker(int_hash)

    #do K-1 additional hashes
    for i in range(0, NUM_HASHES-1):
        int_hash = int( hashlib.sha1(pass_hash + str(i)).hexdigest(), 16) % BIT_ARRAY_SIZE
        found = found & checker(int_hash)

        if (not found): return False


    return found
    

def set_local_file(file):
    global _local_file
    _local_file = file


def set_remote_url(url):
    global _remote_url
    _remote_url = url

    if not (_remote_url.startswith("http://") or _remote_url.startswith("https://")):
        _remote_url = "http://" +  _remote_url



#==============================================================

def _print_usage():
    print "check_pass.py remote [url] [password]"
    print "check_pass.py local [file] [password]"


def main():
    
    remote = False

    if not (len(sys.argv) == 4 or len(sys.argv) == 3):
        _print_usage()
        return
    else:
        file = sys.argv[2]
        if(sys.argv[1] == "remote"):
            set_remote_url(file)
            remote = True
        
        elif (sys.argv[1] == "local"):
            set_local_file(file)
            remote = False

        else:
            print "Unknown search location:", sys.argv[1]
            _print_usage()
            return

        #if password is not entered as command line argument, prompt user
        if len(sys.argv) == 4:
            password = sys.argv[3]
        else:
            password = getpass.getpass("Password:")

        if DEBUG: print "Password:", password
        if ( pwned(password, remote) ):
            print "Oh no - most likely pwned!"
        else:
            print "Good news - no pwnage found!"
            


    

if __name__ == '__main__':
    main()