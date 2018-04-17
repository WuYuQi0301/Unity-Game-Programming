# Hit UFO
编写一个简单的鼠标打飞碟（Hit UFO）游戏
- 内容要求
1. 游戏有n个round，每个round都包括10次trial；
2. 每个trial的飞碟的大小、色彩、发射位置、速度、角度、同时出现的个数都可能不相同。它们由round的ruler控制；
3. 每个trial的飞碟都有随机性，难度总体随着round上升；
4. 鼠标点中得分，得分规则按色彩、大小、速度不同计算，规则自由设定。

- 游戏要求
 - 使用带缓存的工厂模式管理不同飞碟的产生和回收，该工厂必须是场景单实例！使用Singleton模板类实现；
 尽可能使用MVC结构实现人机交互与游戏模型的分离

心得：用a4打类图的草稿的时候，感觉自己在c++里学的面向对象设计都是假的...晚些更博。

[My Blog : Unity HitUFO]{http://wuyq53.space/unity/2018/04/15/HitUFO/#}

待我类图补充完整再来更个新....
![类图]{http://i2.bvimg.com/618639/c42481db2d60f2fd.png}

录屏地址：  
http://v.youku.com/v_show/id_XMzU0NTM5NjcwNA==.html?spm=a2h3j.8428770.3416059.1