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
  ```markdown
  public override void InitCommand() {
        // Initialize command function, All command class should be create here.
        // Command类初始化函数,所有的Command类应当在此进行创建.
        BindCommand(new Test1Command(this));
        BindCommand(new CubeCommand(this));
    }
  ```
  - Create other bussiness Command class drive from class "HnFramework.MVC.Command".
  - Override function "OnStart", and add listener.
  ```markdown
  public override void OnStart() {
        AddListener(CommandEvent.GetScore, OnGetScore);
        AddListener(CommandEvent.AddScore, OnAddScore);
    }
  ```
  
 **3.Create Model**
  - Create model class drive from class "HnFramework.MVC.Model", e.g. "XXModel".
  - Call function "BindModel(enum, XXModel.GetSingleton<XXModel>());" in the function "InitModel" of "SceneCommand".
  ```markdown
  public override void InitModel() {
        // Bind model function, model instance will be destroy with the scene 
        // while you call the method Model.GetInstance, and it works in whole life time 
        // while you call the method Model.GetSingleton.
        // Model数据类在此进行绑定,调用GetSingleton则该数据类全局有效,GetInstance则只在当前场景有效,
        // 场景销毁则该数据类也进行销毁.

        //BindModel(ModelType.ScoreModel, ScoreModel.GetInstance<ScoreModel>());
        BindModel(ModelType.ScoreModel, ScoreModel.GetSingleton<ScoreModel>());
        // BindModel(ModelType.OtherModel,
        // BindModel(...
    }
  ```
  
 **4.Create Mediator**
  - Create mediator class drive from class "HnFramework.MVC.Mediator", e.g. "XXMediator".
  - Override function "OnInit", then get view class and add listener.
  ```markdown
  CubeView _cubeView;
  public override void OnInit() {
        _cubeView = View as CubeView;
        if (null == _cubeView) {
            Debug.LogError("cube view is null");
            return;
        }
        AddListener(MediatorEvent.GetScore, OnGetScore);
    }
  ```
  
 **5.Create View**
  - Create view class drive from class "HnFramework.MVC.View", e.g. "XXView".
  - Override function "InitMediator", and bind mediator.
  ```markdown
  protected override void InitMediator() {
        BindMediator(typeof(CubeMediator));
    }
  ```
  
  **6.Dispatch**
  - You can call function "DispatchCommand(enum)" to make command work(e.g. get model datas) in view or mediator class. 
  - You can call function "DispatchMediator(enum)" to update UI in command class.


###  [Documentation](https://2011fuzhou.gitbook.io/hnmvc/):

For more details see [Gitbook documentation](https://2011fuzhou.gitbook.io/hnmvc/).


### Support or Contact

Contact me 
[twitter:@peiqiangzhou](https://twitter.com/peiqiangzhou) 
[weibo:@bv小强](https://weibo.com/bellusvita)
email:bellusvita@163.com
qq:402599721
