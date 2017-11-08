**m** 0ch
===================


![travis](https://travis-ci.org/CowTard/mOch.svg?branch=master "Travis Test")

----------

To run **m** 0ch you need to place a configuration file in your workspace folder.

Config File
-------------
```ini
[AgentPlatform]

;Internet address of the agent platform (AP).
IP = 127.0.0.1

;Port used by AP's Server
Port = 4321
 
;Compression Algorithms available in the platform
[CompressionAlgorithms]

Compression = "GZIP","DEFLATE", "L4Z"

;Where user's preferences are described
[Preferences]

;As for the preference of the compression algorithm, this variable takes the index of the 
;desired algorithm
;Index [0:]
CompressionAlgorithm = 2

;Machine name is the platform name
MachineName = "ap"
``` 
