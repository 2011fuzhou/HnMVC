## Welcome to HnMVC

HnMVC is a super-lightweight mvc framework base on delegate and event, written specifically for C# and Unity.

**Key features**
- Event system
- View mediation

![image](https://github.com/2011fuzhou/HnMVC/blob/master/HnMVC.png)

### To get started:
 **1.Create Contex**
  - Create a new empty gameobject and add a c# script component.
  - Create a contex class drive from class "HnFramework.MVC.Contex", e.g. "XXContex".
  - Override function "InitCommand".
 
 **2.Create Command**
  - Create a SceneCommand or StartCommand class drive from class "HnFramework.MVC.Command", e.g. "XXCommand".
  - Override function "InitModel".
  - Call function "BindCommand(new XXCommand(this));" in the function "InitCommand" of "XXContex".
  - Create other bussiness Command class drive from class "HnFramework.MVC.Command".
  - Override function "OnStart", and add listener.
  
 **3.Create Model**
  - Create model class drive from class "HnFramework.MVC.Model", e.g. "XXModel".
  - Call function "BindModel(enum, XXModel.GetSingleton<XXModel>());" in the function "InitModel" of "SceneCommand".
  
 **4.Create Mediator**
  - Create mediator class drive from class "HnFramework.MVC.Mediator", e.g. "XXMediator".
  - Override function "OnInit", then get view class and add listener.
  ```markdown
  public override void OnInit() {
        _cubeView = View as CubeView;
        if (null == _cubeView) {
            Debug.LogError("cube view is null");
            return;
        }
        AddListener(MediatorEvent.GetScore, OnGetScore);
    }
  ```
  


Markdown is a lightweight and easy-to-use syntax for styling your writing. It includes conventions for

```markdown
Syntax highlighted code block

# Header 1
## Header 2
### Header 3

- Bulleted
- List

1. Numbered
2. List

**Bold** and _Italic_ and `Code` text

[Link](url) and ![Image](src)
```

For more details see [GitHub Flavored Markdown](https://guides.github.com/features/mastering-markdown/).

### Jekyll Themes

Your Pages site will use the layout and styles from the Jekyll theme you have selected in your [repository settings](https://github.com/2011fuzhou/HnMVC/settings). The name of this theme is saved in the Jekyll `_config.yml` configuration file.

### Support or Contact

Having trouble with Pages? Check out our [documentation](https://help.github.com/categories/github-pages-basics/) or [contact support](https://github.com/contact) and we’ll help you sort it out.
