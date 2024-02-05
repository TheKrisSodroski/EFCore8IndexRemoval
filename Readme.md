# EF Core 8 Index Not Ignored Issue

This github is a minimum reproduction of an issue where EF Core 8 does not ignore Indexes even though they've been explicitly ignored.  

The context takes a generic argument, and a list of Assemblies.  

The context then ignores all types within the Assemblies, and then loops through the the generic argument and removes all indexes explicitly.  

Since indexes are explicitly being ignored, you would expect the model builder to ignore them.  But as you can see in the created script, the index is not ignored.  
