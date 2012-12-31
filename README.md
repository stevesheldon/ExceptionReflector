C# Method Exception Reflector
=============================

This is a simple tool for checking which exceptions are thrown by a method in c#. To use, the user clicks the link 
in the top left of the application to select an assembly/dll. After loading, methods are showin in a tree grouped by
namespace and class. Methods in gray have no exceptions, methods in black can be clicked and the list to the right
shows which exceptions are thrown.


Limitations
===========

* This release will skip methods and classes with generic types.
* There is always the chance that not all dependent dll's will be found. If this happens try copying your compiled dll into the same directory as the dll you want information about.


Acknowledgements
================

This application builds on the knowledge from this article in Stack Overflow:

http://stackoverflow.com/questions/986180/how-can-i-determine-which-exceptions-can-be-thrown-by-a-given-method

This article builds on the ILReader library found here:

http://blogs.msdn.com/b/haibo_luo/archive/2006/11/06/system-reflection-based-ilreader.aspx


Read More Here
==============

http://steves-rv-travels.com/archives/167
