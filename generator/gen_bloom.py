#!/usr/bin/env python

import sys
import mmap
from bitarray import bitarray
import hashlib


K=10
SIZE = 4615205609
P = 0.001

TOTAL_HASHES = 320335236

bloom = bitarray(SIZE)

in_file_name = sys.argv[1]
print "Reading", in_file_name


out_file_name = sys.argv[2]
print "Writing to", out_file_name
out_file = open(out_file_name, "w+b")


count = 0
with open(in_file_name, "r+b") as f:
    # memory-map the file, size 0 means whole file
    mm = mmap.mmap(f.fileno(), 0)
    # read content via standard file methods

    for line in iter(mm.readline, ""):
        str_hash = line.strip()
        
        #we use the sha1 value itself as a hash function
        int_hash = int(str_hash, 16) % SIZE
        bloom[int_hash] = 1

        #do K-1 additional hashes
        for i in range(0, K-1):
            int_hash = int( hashlib.sha1(str_hash + str(i)).hexdigest(), 16) % SIZE
            
            bloom[int_hash] = 1

        count = count + 1
        if count%1000000 == 0:
            print(str(100.0*count/TOTAL_HASHES) + "%")


    f.close()

print "Parsed ", count, " hashes"


bloom.tofile(out_file)
out_file.close()
        
