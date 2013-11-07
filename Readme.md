CSor1k - C# OpenRISC 1000 Emulator
===================================

This is a C# port of [s-macke/jor1k](s-macke/jor1k), the JavaScript
OpenRISC 1000 emulator.


Why?
----

* The `jor1k` emulator is fairly small, yet it can run a full Linux operating
  system. This makes is very intriguing to the author.

* Explore system emulation concepts and optimization.

* Extend the emulator with new devices - for example, ethernet.


Implemented
-----------

* ArrayBuffer, Int32Array, Uint8Array (C# versions of multiview buffers)
* ram


Partially Implmented
--------------------

* (coming soon)

Remaining
---------

* cpu
* ata
* bzip2
* eth
* framebuffer
* keyboard
* system
* uart
* utils
* worker
* terminal
* terminal-input
