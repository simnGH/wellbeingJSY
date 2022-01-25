## Wellbeing

### Simple Guides

#### Add AppSettings (Secrets)
Secrets are environment variables used in the code which change from person to person such as database connection details.
1. Create a file called `secrets.json` in the path specified bellow:
**Mac/Linux** - `~/.microsoft/usersecrets/wellbeing/secrets.json`
**Windows** - `%APPDATA%\Microsoft\UserSecrets\wellbeing\secrets.json`
2. Add the following content to he file changing any details to match your needs:
```
{
    "AppSettings": {
        "RedisConnectionString": "127.0.0.1",
    },
    "datasources": {
        "wellbeing": {
            "database": "wellbeing_dev",
            "username": "root",
            "password": "Developer!",
            "server": "127.0.0.1"
        }
    }
}
```

#### Add css files to view
1. Go to `wellbeing.ui/assets/css`
2. Create the `.css` file
3. Go to wellbeing.ui/Startup.cs and find `services.AddWebOptimizer`
4. Add the following line replacing the first path to the path the file should be rendered (should finish in `.min.css`) - `pipeline.AddCssBundle("/css/core.min.css", "assets/css/core.css").UseContentRoot();`
5. Add css file to the top of the `.cshtml` view required. If it should be available in every page, add this to `wellbeing.ui/Views/Shared/_Layout.cshtml` else add it to the `.cshtml` view required. `<link rel="stylesheet" href="/css/core.min.css" />`

#### Add js files to view
1. Go to `wellbeing.ui/assets/js`
2. Create the `.js` file
3. Go to wellbeing.ui/Startup.cs and find `services.AddWebOptimizer`
4. Add the following line replacing the first path to the path the file should be rendered (should finish in `.js.css`) - `pipeline.AddJavaScriptBundle("/js/core.min.js", "assets/js/core.js").UseContentRoot();`
5. Add css file to the bottom of the `.cshtml` view required. If it should be available in every page, add this to `wellbeing.ui/Views/Shared/_Layout.cshtml` else add it to the `.cshtml` view required. `<script src="/js/core.min.js" asp-append-version="true"></script>`

If added to a specific view, add the file like this:
```
@section Scripts
{
    <script src="/js/core.min.js" asp-append-version="true"></script>
}
```

#### Manage Schema
Feel free to use skeema to manage your database if you have Mac/Linux. Download can be found here. https://www.skeema.io/docs/install/community/

After installing skeema on your dev machine, create a file called .skeema under `wellbeing.db/Schema/`. You can duplicate and rename `wellbeing.db/Schema/.skeema.example` and change the details inside the file.

Once you have the .skeema file in the same directory of your sql scripts (`wellbeing.db/Schema/.skeema`), you can start using the commands bellow. When using skeema, you need to use skeema OPTION development to specify the development environment. We'll create something to automate the development env..Shows difference between target database and local scripts. Will show the scripts it needs to run to update database.
- skeema diff developmentIf there is the potential of data loss, `skeema diff development` will error. You can use this command to approve potential data loss.
- skeema diff --allow-unsafe developmentI recommend using this when developing. This is used to apply changes to the database. If there is potential data loss, it won't run.
- skeema push developmentSame as the command above but it ignores potential data loss.
- skeema push --allow-unsafe development