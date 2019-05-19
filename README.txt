Application wil display a table with the following information -

- Total number of open issues
- Number of open issues that were opened in the last 24 hours
- Number of open issues that were opened more than 24 hours ago but less than 7 days ago
- Number of open issues that were opened more than 7 days ago 


All the information is against github.com


To build the solution open cmd in admin mode
add msbuild.exe to System path 
set Bld_Configuration=Release

Execute Radius.UI\BuildFiles\Rebuild.cmd

you can later deploy it to IIS