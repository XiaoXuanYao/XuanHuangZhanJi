using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    public static string GuanQiaChoosed = "";
    public static int GuanQiaNanDuChoosed = 1;
    public static bool IsSkip = false;
    public static List<string> PlanesID = new List<string>();
    public static List<string> GuanQiaID = new List<string>();
    public delegate void FGDelegate();
    public static FGDelegate Delegates = null;
    public static bool IsZhanDou = false;
    public static MapSpecial ObjsNeed = null;

    public static void PreStart(string GuanQia, MapSpecial ObjectsNeed = null)
    {
        ObjsNeed = ObjectsNeed;
        IsSkip = false;
        for (int i = 0; i < Fade.StringToTransform("Canvas/PreStartGuanQia/JuDianImage").childCount; i++)
        {
            Fade.StringToTransform("Canvas/PreStartGuanQia/JuDianImage").GetChild(i).gameObject.SetActive(false);
        }
        if (ControlCenter.FinishedGuanQia.Contains(GuanQia))
        {
            Fade.StringToTransform("Canvas/PreStartGuanQia/Skip").GetComponent<CanvasGroup>().alpha = 0;
        }
        else
        {
            Fade.StringToTransform("Canvas/PreStartGuanQia/Skip").GetComponent<CanvasGroup>().alpha = 1;
        }
        if (ControlCenter.CouldStartGuanQia.Contains(GuanQia))
        {
            GuanQiaChoosed = GuanQia;
            switch (GuanQia)
            {
                #region 关卡 1_1 剧情及相关介绍
                case "1_1":
                    Fade.StringToTransform("Canvas/PreStartGuanQia/JuDianImage/XiaoXingJuDian").gameObject.SetActive(true);
                    Fade.StringToTransform("Canvas/PreStartGuanQia/Type").GetComponent<TextMeshProUGUI>().text
                        = "类型：<color=#d88>敌方战机小队先锋</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/ShouWeiGrade").GetComponent<TextMeshProUGUI>().text
                        = "守卫：<color=#aaa>黄级</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/WenMing").GetComponent<TextMeshProUGUI>().text
                        = "文明：<color=#aaa>无</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/RenWu").GetComponent<TextMeshProUGUI>().text
                        = "任务：少于三架敌机通过防线";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/QingBao/Text").GetComponent<TextMeshProUGUI>().text
                        = @"情报：<color=#eee>[注：故事纯属虚构]
背景：2243年乾坤九号探测器在距地约六千光年处首次发现地外生命，出于对外星文明好奇和探索宇宙的渴望，我们与该生命进行了多次谨慎交流，尽管我们已经十分小心，尽全力防止地球信息外泄，但仍被对方用类似读心术的手段了解到地球文明处于约1.4级的水平。由于发展对资源消耗过大，他们决定侵入我方文明，达到奴役或控制我恒星系的目的。我们自然不能坐以待毙，因此决定先派出战机估测敌方实力。
<color=#6ac>[探测器信息]</color> 发现七架战机正在从太阳系外接近，根据速度判断为黄级。
-----=|ad?ac?9000/err-10[翻译失败]
<color=#6ac>[探测器已被击毁]</color></color>";
                    break;
                #endregion

                #region 关卡 1_2 剧情及相关介绍
                case "1_2":
                    Fade.StringToTransform("Canvas/PreStartGuanQia/JuDianImage/XiaoXingJuDian").gameObject.SetActive(true);
                    Fade.StringToTransform("Canvas/PreStartGuanQia/Type").GetComponent<TextMeshProUGUI>().text
                        = "类型：<color=#d88>敌方战机小队先锋</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/ShouWeiGrade").GetComponent<TextMeshProUGUI>().text
                        = "守卫：<color=#aaa>黄级</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/WenMing").GetComponent<TextMeshProUGUI>().text
                        = "文明：<color=#aaa>无</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/RenWu").GetComponent<TextMeshProUGUI>().text
                        = "任务：少于三架敌机通过防线";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/QingBao/Text").GetComponent<TextMeshProUGUI>().text
                        = @"情报：<color=#eee>
击退了敌人探子，但这只是开始。敌方派遣了大量战机，请您一定坚守防线，为我军研发相应反制武器争取时间。</color>";
                    break;
                #endregion

                #region 关卡 1_3 剧情及相关介绍
                case "1_3":
                    Fade.StringToTransform("Canvas/PreStartGuanQia/JuDianImage/XiaoXingJuDian").gameObject.SetActive(true);
                    Fade.StringToTransform("Canvas/PreStartGuanQia/Type").GetComponent<TextMeshProUGUI>().text
                        = "类型：<color=#d88>敌方战机小队先锋精锐</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/ShouWeiGrade").GetComponent<TextMeshProUGUI>().text
                        = "守卫：<color=#aaa>黄级</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/WenMing").GetComponent<TextMeshProUGUI>().text
                        = "文明：<color=#aaa>无</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/RenWu").GetComponent<TextMeshProUGUI>().text
                        = "任务：少于三架敌机通过防线";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/QingBao/Text").GetComponent<TextMeshProUGUI>().text
                        = @"情报：<color=#eee>
<color=#6ac>[探测器信息]</color>前方出现三架战机，据分析应为敌先锋精锐。
<color=#6ac>[战舰指挥中心]</color>战机群即将完成生产。我们能够在敌军大批量到来前拥有一定反制措施，但您才是真正扭转乾坤的关键！</color>";
                    break;
                #endregion

                #region 关卡 1_4 剧情及相关介绍
                case "1_4":
                    Fade.StringToTransform("Canvas/PreStartGuanQia/JuDianImage/XiaoXingJuDian").gameObject.SetActive(true);
                    Fade.StringToTransform("Canvas/PreStartGuanQia/Type").GetComponent<TextMeshProUGUI>().text
                        = "类型：<color=#d88>敌方战机小队前锋</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/ShouWeiGrade").GetComponent<TextMeshProUGUI>().text
                        = "守卫：<color=#aaa>黄级</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/WenMing").GetComponent<TextMeshProUGUI>().text
                        = "文明：<color=#aaa>1.05 级</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/RenWu").GetComponent<TextMeshProUGUI>().text
                        = "任务：少于三架敌机通过防线";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/QingBao/Text").GetComponent<TextMeshProUGUI>().text
                        = @"情报：<color=#eee>
<color=#6ac>[战舰指挥中心]</color>    我们可以反击了。基地很快就会派来新的战机支援，争取消灭他们的前锋。
……不过注意防御，这次也许会是一场惨烈的战斗。</color>";
                    break;
                #endregion

                #region 关卡 1_5 剧情及相关介绍
                case "1_5":
                    Fade.StringToTransform("Canvas/PreStartGuanQia/JuDianImage/XiaoXingJuDian").gameObject.SetActive(true);
                    Fade.StringToTransform("Canvas/PreStartGuanQia/Type").GetComponent<TextMeshProUGUI>().text
                        = "类型：<color=#d88>敌方黄级战船</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/ShouWeiGrade").GetComponent<TextMeshProUGUI>().text
                        = "守卫：<color=#aaa>黄级</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/WenMing").GetComponent<TextMeshProUGUI>().text
                        = "文明：<color=#aaa>1.08 级</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/RenWu").GetComponent<TextMeshProUGUI>().text
                        = "任务：击毁敌方战机";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/QingBao/Text").GetComponent<TextMeshProUGUI>().text
                        = @"情报：<color=#eee>
<color=#6ac>[战舰指挥中心]</color>    保卫的最后一战，之后我们能有一段时间来恢复士气并研发新型武器。
    我们把你视为希望。前进！你永远不会是一个人战斗。</color>";
                    break;
                #endregion

                #region 关卡 1_6 剧情及相关介绍
                case "1_6":
                    Fade.StringToTransform("Canvas/PreStartGuanQia/JuDianImage/XiaoXingJuDian").gameObject.SetActive(true);
                    Fade.StringToTransform("Canvas/PreStartGuanQia/Type").GetComponent<TextMeshProUGUI>().text
                        = "类型：<color=#d88>敌方战机小队</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/ShouWeiGrade").GetComponent<TextMeshProUGUI>().text
                        = "守卫：<color=#aaa>黄级</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/WenMing").GetComponent<TextMeshProUGUI>().text
                        = "文明：<color=#aaa>无</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/RenWu").GetComponent<TextMeshProUGUI>().text
                        = "任务：击毁敌方战机";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/QingBao/Text").GetComponent<TextMeshProUGUI>().text
                        = @"情报：<color=#eee>
<color=#6ac>[战舰指挥中心]</color>    你作为伟大的战士们中的一员，理当知晓以下情报。
<color=#6ac>[数据传输中……]</color>
<color=#6ac>[密文：关于与侵入文明的交流]</color>
    <color=#6ac>[破译信号]…………完成</color>
    <color=#6ac>[发送同频信号]…………完成</color>
    <color=#6ac>我方：</color>我们是你们进攻的文明，现尝试和你们进行沟通。
    <color=#6ac>我方：</color>战争对双方都无好处，何必如此，如果你们有意愿我们可以合作。
    <color=#6ac>敌方：</color>不需要合作，你们实力并没有我们强，只要打破你们的防御一切都是我们的。
    <color=#6ac>我方：</color>那样你们需要付出更大的代价，甚至发展将会倒退。
    <color=#6ac>敌方：</color>你们没有那些能耐。不用再说更多，我们做过的决定永远不会撤销。
    <color=#6ac>我方：</color>……对手请留下名称。
    <color=#6ac>敌方：</color>凡却——。在被毁灭前明白自己的敌人吧！
    <color=#6ac>[信号终止]</color>
仅在查阅的时间后，就观察到敌方一小队战机正在赶来，先击毁他们。</color>";
                    break;
                #endregion

                #region 关卡 1_7 剧情及相关介绍
                case "1_7":
                    Fade.StringToTransform("Canvas/PreStartGuanQia/JuDianImage/XiaoXingJuDian").gameObject.SetActive(true);
                    Fade.StringToTransform("Canvas/PreStartGuanQia/Type").GetComponent<TextMeshProUGUI>().text
                        = "类型：<color=#d88>敌方黄级战船</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/ShouWeiGrade").GetComponent<TextMeshProUGUI>().text
                        = "守卫：<color=#aaa>黄级</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/WenMing").GetComponent<TextMeshProUGUI>().text
                        = "文明：<color=#aaa>1.08 级</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/RenWu").GetComponent<TextMeshProUGUI>().text
                        = "任务：击毁敌方战机";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/QingBao/Text").GetComponent<TextMeshProUGUI>().text
                        = @"情报：<color=#eee>
<color=#6ac>[任务规划]</color>    在这片区域中被划分为了无数片区域，由众多战舰共同守卫，我们负责的就是这一片。阻止敌方突破防线。</color>";
                    break;
                #endregion

                #region 关卡 1_8 剧情及相关介绍
                case "1_8":
                    Fade.StringToTransform("Canvas/PreStartGuanQia/JuDianImage/XiaoXingJuDian").gameObject.SetActive(true);
                    Fade.StringToTransform("Canvas/PreStartGuanQia/Type").GetComponent<TextMeshProUGUI>().text
                        = "类型：<color=#d88>敌方玄级战船</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/ShouWeiGrade").GetComponent<TextMeshProUGUI>().text
                        = "守卫：<color=#4a4>玄级</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/WenMing").GetComponent<TextMeshProUGUI>().text
                        = "文明：<color=#aaa>1.08 级</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/RenWu").GetComponent<TextMeshProUGUI>().text
                        = "任务：击毁敌方战机";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/QingBao/Text").GetComponent<TextMeshProUGUI>().text
                        = @"情报：<color=#eee>
<color=#6ac>[探测器信息]</color>    观察到了一个奇怪形状的疑似战舰物体正在赶来，观测到较高能量密度物体。</color>";
                    break;
                #endregion

                #region 关卡 2_1 剧情及相关介绍
                case "2_1":
                    Fade.StringToTransform("Canvas/PreStartGuanQia/JuDianImage/XiaoXingJuDian").gameObject.SetActive(true);
                    Fade.StringToTransform("Canvas/PreStartGuanQia/Type").GetComponent<TextMeshProUGUI>().text
                        = "类型：<color=#d88>敌方黄级战船</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/ShouWeiGrade").GetComponent<TextMeshProUGUI>().text
                        = "守卫：<color=#aaa>黄级</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/WenMing").GetComponent<TextMeshProUGUI>().text
                        = "文明：<color=#aaa>1.08 级</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/RenWu").GetComponent<TextMeshProUGUI>().text
                        = "任务：击毁敌方战机";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/QingBao/Text").GetComponent<TextMeshProUGUI>().text
                        = @"情报：<color=#eee>
<color=#6ac>[战舰指挥中心]</color>    被动防御终不是办法，经决议我们派遣您前往系外，AU-1138恒星区，去寻找新的物质与技术。</color>";
                    break;
                #endregion

                #region 关卡 2_2 剧情及相关介绍
                case "2_2":
                    Fade.StringToTransform("Canvas/PreStartGuanQia/JuDianImage/XiaoXingJuDian").gameObject.SetActive(true);
                    Fade.StringToTransform("Canvas/PreStartGuanQia/Type").GetComponent<TextMeshProUGUI>().text
                        = "类型：<color=#d88>敌方黄级战船</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/ShouWeiGrade").GetComponent<TextMeshProUGUI>().text
                        = "守卫：<color=#aaa>黄级</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/WenMing").GetComponent<TextMeshProUGUI>().text
                        = "文明：<color=#aaa>无</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/RenWu").GetComponent<TextMeshProUGUI>().text
                        = "任务：击毁敌方战机";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/QingBao/Text").GetComponent<TextMeshProUGUI>().text
                        = @"情报：<color=#eee>
<color=#6ac>[日志]</color>    遇到了一队敌方战机，他们似乎在尝试操控火元素进行攻击，击败他们或许会有些收获？</color>";
                    break;
                #endregion

                #region 关卡 2_3 剧情及相关介绍
                case "2_3":
                    Fade.StringToTransform("Canvas/PreStartGuanQia/JuDianImage/XiaoXingJuDian").gameObject.SetActive(true);
                    Fade.StringToTransform("Canvas/PreStartGuanQia/Type").GetComponent<TextMeshProUGUI>().text
                        = "类型：<color=#d88>敌方黄级战船</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/ShouWeiGrade").GetComponent<TextMeshProUGUI>().text
                        = "守卫：<color=#aaa>黄级</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/WenMing").GetComponent<TextMeshProUGUI>().text
                        = "文明：<color=#aaa>无</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/RenWu").GetComponent<TextMeshProUGUI>().text
                        = "任务：击毁敌方战机";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/QingBao/Text").GetComponent<TextMeshProUGUI>().text
                        = @"情报：<color=#eee>
<color=#6ac>[日志]</color>    发现了两架未知的不知来自哪里的战机，他们有浓郁的火元素气息，我们尝试进行交涉，但他们没有选择相信我们。
只好先击败他们再去谈谈了……</color>";
                    break;
                #endregion

                #region 关卡 2_4 剧情及相关介绍
                case "2_4":
                    Fade.StringToTransform("Canvas/PreStartGuanQia/JuDianImage/XiaoXingJuDian").gameObject.SetActive(true);
                    Fade.StringToTransform("Canvas/PreStartGuanQia/Type").GetComponent<TextMeshProUGUI>().text
                        = "类型：<color=#d88>敌方黄级战舰小队</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/ShouWeiGrade").GetComponent<TextMeshProUGUI>().text
                        = "守卫：<color=#aaa>黄级</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/WenMing").GetComponent<TextMeshProUGUI>().text
                        = "文明：<color=#aaa>无</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/RenWu").GetComponent<TextMeshProUGUI>().text
                        = "任务：击毁敌方战机";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/QingBao/Text").GetComponent<TextMeshProUGUI>().text
                        = @"情报：<color=#eee>
<color=#6ac>[日志]</color>    他们同意我们与我们进行交流。从得到的信息得知，火元素是由晶石高压下催化转化后经一系列处理而来，基本原理
并不难得到，但如何保证火元素的稳定性是其机密。</color>";
                    break;
                #endregion

                #region 关卡 2_5 剧情及相关介绍
                case "2_5":
                    Fade.StringToTransform("Canvas/PreStartGuanQia/JuDianImage/XiaoXingJuDian").gameObject.SetActive(true);
                    Fade.StringToTransform("Canvas/PreStartGuanQia/Type").GetComponent<TextMeshProUGUI>().text
                        = "类型：<color=#d88>敌方玄级战舰</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/ShouWeiGrade").GetComponent<TextMeshProUGUI>().text
                        = "守卫：<color=#4a4>玄级</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/WenMing").GetComponent<TextMeshProUGUI>().text
                        = "文明：<color=#aaa>无</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/RenWu").GetComponent<TextMeshProUGUI>().text
                        = "任务：击毁敌方战机";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/QingBao/Text").GetComponent<TextMeshProUGUI>().text
                        = @"情报：<color=#eee>
<color=#6ac>[日志]</color>    他们自称为落羽文明，正处于战争中，而敌人正是凡却文明，如果能帮他们在关键时刻扭转时局，就将火元素相关科技告诉我们，并结为盟友。据落羽自己的描述，落羽在科技，尤其热武器方面不擅长，但对元素有着很深的了解，在凡却入侵时，因为主攻的火元素被敌人用科技反制，才落入下风，我们只需要协助他们打破玄阶战舰的防御即可。</color>";
                    break;
                #endregion

                #region 关卡 2_6 剧情及相关介绍
                case "2_6":
                    Fade.StringToTransform("Canvas/PreStartGuanQia/JuDianImage/XiaoXingJuDian").gameObject.SetActive(true);
                    Fade.StringToTransform("Canvas/PreStartGuanQia/Type").GetComponent<TextMeshProUGUI>().text
                        = "类型：<color=#d88>敌方玄级战机群</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/ShouWeiGrade").GetComponent<TextMeshProUGUI>().text
                        = "守卫：<color=#4a4>黄级</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/WenMing").GetComponent<TextMeshProUGUI>().text
                        = "文明：<color=#aaa>无</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/RenWu").GetComponent<TextMeshProUGUI>().text
                        = "任务：击毁敌方战机";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/QingBao/Text").GetComponent<TextMeshProUGUI>().text
                        = @"情报：<color=#eee>
<color=#6ac>[密文：与雨落文明契约时]</color>
    <color=#6ac>羽落：</color>“我们会派遣使者跟您前往签订盟约，一同对付凡却。毕竟并不是所有的文明都喜欢战斗，我们只是想和平地探索元素——那个我们一生所追求的秘密。”
    <color=#6ac>羽落：</color>“所以不必担心背叛——虽然这没有说服力，仅是为了取得一点信任而已。作为盟友，信任是关键而又重要的东西。”
    <color=#6ac>羽落：</color>“根据您的行为不难看出您对凡却文明有一定的了解——尤其是对付他们。”
    <color=#6ac>羽落：</color>“我们希望能够交换一些心得，内容可进行商定。契约已制作完毕，请您向您的文明陈述我们的意图与苦衷。”
    <color=#6ac>我：</color>“我会将您的盟约带回至本部，请他们进行决定。”</color>";
                    break;
                #endregion

                #region 关卡 2_7 剧情及相关介绍
                case "2_7":
                    Fade.StringToTransform("Canvas/PreStartGuanQia/JuDianImage/XiaoXingJuDian").gameObject.SetActive(true);
                    Fade.StringToTransform("Canvas/PreStartGuanQia/Type").GetComponent<TextMeshProUGUI>().text
                        = "类型：<color=#d88>敌方玄级战机群</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/ShouWeiGrade").GetComponent<TextMeshProUGUI>().text
                        = "守卫：<color=#4a4>黄级</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/WenMing").GetComponent<TextMeshProUGUI>().text
                        = "文明：<color=#aaa>无</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/RenWu").GetComponent<TextMeshProUGUI>().text
                        = "任务：击毁敌方战机";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/QingBao/Text").GetComponent<TextMeshProUGUI>().text
                        = @"情报：<color=#eee>
<color=#6ac>[日志]</color> 2247年，带着羽落文明的契约结盟书踏上回到故乡的道路。
<color=#6ac>[批注]</color> 敌人战机永远无穷无尽似的，他们不担心引起其它文明的注意吗，而且制作战机的材料又是从哪里弄到这么多的？";
                    break;
                #endregion

                #region 关卡 2_8 剧情及相关介绍
                case "2_8":
                    Fade.StringToTransform("Canvas/PreStartGuanQia/JuDianImage/XiaoXingJuDian").gameObject.SetActive(true);
                    Fade.StringToTransform("Canvas/PreStartGuanQia/Type").GetComponent<TextMeshProUGUI>().text
                        = "类型：<color=#d88>敌方玄级战机群</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/ShouWeiGrade").GetComponent<TextMeshProUGUI>().text
                        = "守卫：<color=#4a4>黄级</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/WenMing").GetComponent<TextMeshProUGUI>().text
                        = "文明：<color=#aaa>无</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/RenWu").GetComponent<TextMeshProUGUI>().text
                        = "任务：击毁敌方战机";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/QingBao/Text").GetComponent<TextMeshProUGUI>().text
                        = @"情报：<color=#eee>
<color=#6ac>[日志]</color> 2248年，根本没有预料到会在归途遇到凡却的一颗人造卫星，不幸中的万幸是我们有羽落给的火元素附着卷轴，它可以在一定时间内帮助我们击穿卫星的铁-硅质超装甲层。
<color=#6ac>[关于火元素推进子弹增加威力的实验]</color> 某天某个羽落人的[魔法]追踪敌方子弹并刚好打在了子弹的后端（P = 1x10^(-8)），敌方子弹瞬间获得极为强大的动力，达到了2.7%光速，击毁了直线上的十几艘战机并消失。羽落文明于是开始研究火元素与各种物质的关系。";
                    break;
                #endregion

                #region 关卡 T_1 剧情及相关介绍
                case "T_1":
                    Fade.StringToTransform("Canvas/PreStartGuanQia/JuDianImage/XiaoXingJuDian").gameObject.SetActive(true);
                    Fade.StringToTransform("Canvas/PreStartGuanQia/Type").GetComponent<TextMeshProUGUI>().text
                        = "类型：<color=#d88>敌方黄级战机</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/ShouWeiGrade").GetComponent<TextMeshProUGUI>().text
                        = "守卫：<color=#aaa>黄级</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/WenMing").GetComponent<TextMeshProUGUI>().text
                        = "文明：<color=#aaa>无</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/RenWu").GetComponent<TextMeshProUGUI>().text
                        = "任务：击毁敌方战机";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/QingBao/Text").GetComponent<TextMeshProUGUI>().text
                        = @"情报：<color=#eee>
<color=#6ac>[教程] </color>基础 · 移动教学";
                    break;
                #endregion

                #region 关卡 T_2 剧情及相关介绍
                case "T_2":
                    Fade.StringToTransform("Canvas/PreStartGuanQia/JuDianImage/XiaoXingJuDian").gameObject.SetActive(true);
                    Fade.StringToTransform("Canvas/PreStartGuanQia/Type").GetComponent<TextMeshProUGUI>().text
                        = "类型：<color=#d88>敌方黄级战机</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/ShouWeiGrade").GetComponent<TextMeshProUGUI>().text
                        = "守卫：<color=#aaa>黄级</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/WenMing").GetComponent<TextMeshProUGUI>().text
                        = "文明：<color=#aaa>无</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/RenWu").GetComponent<TextMeshProUGUI>().text
                        = "任务：击毁敌方战机";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/QingBao/Text").GetComponent<TextMeshProUGUI>().text
                        = @"情报：<color=#eee>
<color=#6ac>[教程] </color>基础 · 攻击教学";
                    break;
                #endregion

                #region 关卡 T_3 剧情及相关介绍
                case "T_3":
                    Fade.StringToTransform("Canvas/PreStartGuanQia/JuDianImage/XiaoXingJuDian").gameObject.SetActive(true);
                    Fade.StringToTransform("Canvas/PreStartGuanQia/Type").GetComponent<TextMeshProUGUI>().text
                        = "类型：<color=#d88>敌方黄级战机</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/ShouWeiGrade").GetComponent<TextMeshProUGUI>().text
                        = "守卫：<color=#aaa>黄级</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/WenMing").GetComponent<TextMeshProUGUI>().text
                        = "文明：<color=#aaa>无</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/RenWu").GetComponent<TextMeshProUGUI>().text
                        = "任务：击毁敌方战机";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/QingBao/Text").GetComponent<TextMeshProUGUI>().text
                        = @"情报：<color=#eee>
<color=#6ac>[教程] </color>进阶 · 移动教学";
                    break;
                #endregion

                #region 关卡 碎片获取 FS-1 剧情及相关介绍
                case "SuiPian_FS_1":
                    Fade.StringToTransform("Canvas/PreStartGuanQia/JuDianImage/XiaoXingJuDian").gameObject.SetActive(true);
                    Fade.StringToTransform("Canvas/PreStartGuanQia/Type").GetComponent<TextMeshProUGUI>().text
                        = "类型：<color=#d88>敌方黄级战机群</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/ShouWeiGrade").GetComponent<TextMeshProUGUI>().text
                        = "守卫：<color=#aaa>黄级</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/WenMing").GetComponent<TextMeshProUGUI>().text
                        = "文明：<color=#aaa>无</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/RenWu").GetComponent<TextMeshProUGUI>().text
                        = "任务：击毁敌方战机";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/QingBao/Text").GetComponent<TextMeshProUGUI>().text
                        = @"情报：<color=#eee>
<color=#999>开启关卡需要[通行凭证]x1</color>
敌人大举进攻，来犯我境，战士，你能守住自己的区域吗？</color>";
                    break;
                #endregion

                #region 关卡 碎片获取 TU-1 剧情及相关介绍
                case "SuiPian_TU_1":
                    Fade.StringToTransform("Canvas/PreStartGuanQia/JuDianImage/XiaoXingJuDian").gameObject.SetActive(true);
                    Fade.StringToTransform("Canvas/PreStartGuanQia/Type").GetComponent<TextMeshProUGUI>().text
                        = "类型：<color=#d88>敌方黄级战机群</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/ShouWeiGrade").GetComponent<TextMeshProUGUI>().text
                        = "守卫：<color=#aaa>黄级</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/WenMing").GetComponent<TextMeshProUGUI>().text
                        = "文明：<color=#aaa>无</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/RenWu").GetComponent<TextMeshProUGUI>().text
                        = "任务：击毁敌方战机";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/QingBao/Text").GetComponent<TextMeshProUGUI>().text
                        = @"情报：<color=#eee>
<color=#999>开启关卡需要[通行凭证]x1</color>
敌人大举进攻，来犯我境，战士，你能守住自己的区域吗？</color>";
                    break;
                #endregion

                #region 关卡 碎片获取 BR-1 剧情及相关介绍
                case "SuiPian_HZ_1":
                    Fade.StringToTransform("Canvas/PreStartGuanQia/JuDianImage/XiaoXingJuDian").gameObject.SetActive(true);
                    Fade.StringToTransform("Canvas/PreStartGuanQia/Type").GetComponent<TextMeshProUGUI>().text
                        = "类型：<color=#d88>敌方黄级战机群</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/ShouWeiGrade").GetComponent<TextMeshProUGUI>().text
                        = "守卫：<color=#aaa>黄级</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/WenMing").GetComponent<TextMeshProUGUI>().text
                        = "文明：<color=#aaa>无</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/RenWu").GetComponent<TextMeshProUGUI>().text
                        = "任务：击毁敌方战机";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/QingBao/Text").GetComponent<TextMeshProUGUI>().text
                        = @"情报：<color=#eee>
<color=#999>开启关卡需要[通行凭证]x1</color>
敌人大举进攻，来犯我境，战士，你能守住自己的区域吗？</color>";
                    break;
                #endregion

                #region 关卡 碎片获取 BR-1 剧情及相关介绍
                case "SuiPian_BR_1":
                    Fade.StringToTransform("Canvas/PreStartGuanQia/JuDianImage/XiaoXingJuDian").gameObject.SetActive(true);
                    Fade.StringToTransform("Canvas/PreStartGuanQia/Type").GetComponent<TextMeshProUGUI>().text
                        = "类型：<color=#d88>敌方黄级战机群</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/ShouWeiGrade").GetComponent<TextMeshProUGUI>().text
                        = "守卫：<color=#aaa>黄级</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/WenMing").GetComponent<TextMeshProUGUI>().text
                        = "文明：<color=#aaa>无</color>";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/RenWu").GetComponent<TextMeshProUGUI>().text
                        = "任务：击毁敌方战机";
                    Fade.StringToTransform("Canvas/PreStartGuanQia/QingBao/Text").GetComponent<TextMeshProUGUI>().text
                        = @"情报：<color=#eee>
<color=#999>开启关卡需要[通行凭证]x1</color>
敌人大举进攻，来犯我境，战士，你能守住自己的区域吗？</color>";
                    break;
                    #endregion
            }
            if (!ControlCenter.FinishedGuanQia.Contains(GuanQia))
            {
                Fade.StringToTransform("Canvas/PreStartGuanQia/NanDu").GetComponent<CanvasGroup>().alpha = 0.5F;
                Fade.StringToTransform("Canvas/PreStartGuanQia/NanDu/Slider").GetComponent<Slider>().value = 1;
                Fade.StringToTransform("Canvas/PreStartGuanQia/NanDu").GetComponent<CanvasGroup>().interactable = false;
            }
            else
            {
                Fade.StringToTransform("Canvas/PreStartGuanQia/NanDu").GetComponent<CanvasGroup>().alpha = 1;
                Fade.StringToTransform("Canvas/PreStartGuanQia/NanDu").GetComponent<CanvasGroup>().interactable = true;
            }
            GameObject.Find("EventSystem").GetComponent<MessageCenter>().StartCoroutine(SetScrollbar(
                Fade.StringToTransform("Canvas/PreStartGuanQia/QingBao/Scrollbar"), 1));
            Fade.NewFade("Canvas/PreStartGuanQia", 0, 1, 0.4F);
            Fade.NewFade("Canvas/Map", 1, 0, 0.25F);
            Button B = Fade.StringToTransform("Canvas/PreStartGuanQia/Start").GetComponent<Button>();
            B.onClick.RemoveAllListeners();
            B.onClick.AddListener(StartMap);
        }
        else
        {
            ShowMessage.Message("关卡未开启");
        }
    }

    static IEnumerator SetScrollbar(Transform Obj, float Value)
    {
        yield return new WaitForFixedUpdate();
        Obj.GetComponent<Scrollbar>().value = Value;
    }

    public static void StartMap()
    {
        if (ObjsNeed != null)
        {
            foreach (MapSpecial.ObjectMes M in ObjsNeed.ObjsNeed)
            {
                if (ObjectSystem.HasObject(M.Name, M.Num))
                {
                    ObjectSystem.DeleteThings(M.Name, M.Num);
                }
                else
                {
                    ShowMessage.Message("开启关卡所需物品不足");
                    Fade.NewFade("Canvas/PreStartGuanQia", 1, 0, 0.3F);
                    ClickUI.ChangeShowButtons(true);
                    return;
                }
            }
        }
        Button B = Fade.StringToTransform("Canvas/PreStartGuanQia/Start").GetComponent<Button>();
        B.onClick.RemoveAllListeners();
        Fade.NewFade("Canvas/ControlButtons", 0, 1, 0.5F);
        Fade.StringToTransform("Canvas/ControlButtons").GetComponent<CanvasGroup>().blocksRaycasts = true;
        CheckDiPass.DiPass = 0;
        HasFailed = false;
        ShiLiBi = 1;
        GuanQiaNanDuChoosed = (int)Fade.StringToTransform("Canvas/PreStartGuanQia/NanDu/Slider").GetComponent<Slider>().value;

        if (Fade.StringToTransform("Canvas/PreStartGuanQia").gameObject.activeSelf)
        {
            Fade.NewFade("Canvas/PreStartGuanQia", 1, 0, 0.5F);
        }
        List<Planes> P = new List<Planes>();
        switch (GuanQiaChoosed)
        {
            case "1_1":
                P = GuanQia1_1.CreateMap();
                break;
            case "1_2":
                P = GuanQia1_2.CreateMap();
                break;
            case "1_3":
                P = GuanQia1_3.CreateMap();
                break;
            case "1_4":
                P = GuanQia1_4.CreateMap();
                break;
            case "1_5":
                P = GuanQia1_5.CreateMap();
                break;
            case "1_6":
                P = GuanQia1_6.CreateMap();
                break;
            case "1_7":
                P = GuanQia1_7.CreateMap();
                break;
            case "1_8":
                P = GuanQia1_8.CreateMap();
                break;
            case "2_1":
                P = GuanQia2_1.CreateMap();
                break;
            case "2_2":
                P = GuanQia2_2.CreateMap();
                break;
            case "2_3":
                P = GuanQia2_3.CreateMap();
                break;
            case "2_4":
                P = GuanQia2_4.CreateMap();
                break;
            case "2_5":
                P = GuanQia2_5.CreateMap();
                break;
            case "2_6":
                P = GuanQia2_6.CreateMap();
                break;
            case "2_7":
                P = GuanQia2_7.CreateMap();
                break;
            case "2_8":
                P = GuanQia2_8.CreateMap();
                GameObject.Find("MainCamera").GetComponent<Camera>().orthographicSize = 8F;
                GameObject.Find("MainCamera").transform.position = new Vector3(0, 2, -10);
                break;
            case "T_1":
                P = GuanQiaT_1.CreateMap();
                break;
            case "T_2":
                P = GuanQiaT_2.CreateMap();
                break;
            case "T_3":
                P = GuanQiaT_3.CreateMap();
                Transform Obj = Instantiate(GameObject.Find("ObjectModels").transform.Find("None"), GameObject.Find("Space").transform);
                Obj.gameObject.AddComponent<Special_T_3>();
                Obj.gameObject.SetActive(true);
                break;
            case "SuiPian_FS_1":
                P = GuanQia_SuiPian_FS_1.CreateMap();
                break;
            case "SuiPian_TU_1":
                P = GuanQia_SuiPian_TU_1.CreateMap();
                break;
            case "SuiPian_HZ_1":
                P = GuanQia_SuiPian_HZ_1.CreateMap();
                break;
            case "SuiPian_BR_1":
                P = GuanQia_SuiPian_BR_1.CreateMap();
                break;
        }
        GameObject.Find("EventSystem").GetComponent<MessageCenter>().StartCoroutine(PutPlanes(P, GuanQiaNanDuChoosed));
        IsZhanDou = true;
    }

    public static bool StopPutPlanes = false;
    public static System.DateTime StartTime;
    static float ShiLiBi = 1;
    public static float Fortune = 0;

    public static IEnumerator PutPlanes(List<Planes> P, int DifficultNum = 0)
    {
        if (GuanQiaChoosed.Split('_')[0] == "T")
        {
            StopPutPlanes = true;
            while (StopPutPlanes)
            {
                yield return new WaitForFixedUpdate();
            }
        }
        StartTime = System.DateTime.Now;
        Weapon.StartAll();
        string thisGuanQiaID = (System.DateTime.Now - System.DateTime.MinValue).Ticks.ToString()
            + ((int)(Random.value * 1000)).ToString() + GuanQiaChoosed;
        GuanQiaID.Add(thisGuanQiaID);

        float thisShengMing = GameObject.Find("MyPlane").GetComponent<Inspector>().ShengMing[1];
        float thisGongJi = GameObject.Find("MyPlane").GetComponent<Inspector>().GongJi;
        PlaneData Pd = PlanesMessage.GetPlaneDataByName(PlanesMessage.ChuZhanPlane);
        float WNum = 0;
        float WValp = 0;
        for(int i = 0; i < Pd.WuQi.Count; i++)
        {
            if (Pd.WuQi[i].Kind == WuQiKind.WuQi)
            {
                WValp += Pd.WuQi[i].GongJiAdd / 100;
                WValp += Pd.WuQi[i].PerIntervalTime - 1;
                WNum++;
            }
            if (Pd.WuQi[i].Kind == WuQiKind.HuDun)
            {
                WValp += Mathf.Max(Pd.WuQi[i].HuDunMax - 50, 0) / 750;
            }
        }
        thisGongJi += 18 + Pd.GongJiAddNum;
        thisGongJi *= (1 + WValp / WNum) * (1 + Pd.GongJiAddPercent);
        float TCNum = 0;

        for (int i = 0; i < P.Count; i++)
        {
            if (IsSkip)
            {
                break;
            }
            if (P[i].RandomDuringTime == "")
            {
                yield return new WaitForSeconds(P[i].DuringTime);
            }
            else
            {
                yield return new WaitForSeconds(Eval(P[i].RandomDuringTime, P[i]));
            }

            if (!GuanQiaID.Contains(thisGuanQiaID))  // 如果当前关卡不存在（ID不在列表GuanQiaID中）
            {
                yield break;  // 结束关卡
            }

            ShiLiBi = ShiLiBi * TCNum + P[i].GongJi / thisGongJi * 0.95F + (float)Mathf.Pow(Mathf.Max(P[i].ShengMing[1] - thisShengMing, 0) / thisShengMing, 0.5F) / 71;
            TCNum++;
            ShiLiBi /= TCNum;

            //Vector2[] TempValue = new Vector2[20];
            foreach (string S in P[i].RandomRoad)
            {
                Vector2 Value = new Vector2();
                Value.x = Eval(S.Split('_')[1]);
                Value.y = Eval(S.Split('_')[2]);
                P[i].Road.Points[int.Parse(S.Split('_')[0])] = Value;
            }

            Transform Obj = Instantiate(P[i].ModleObject, GameObject.Find("Space").transform);
            float FinalFadeOpacity = 1;

            if (Obj.GetComponent<Move>())
            {
                DestroyImmediate(Obj.GetComponent<Move>());
                DestroyImmediate(Obj.GetComponent<Inspector>());
                Obj.gameObject.AddComponent<DiMove>();
                Inspector I = Obj.gameObject.AddComponent<Inspector>();
                I.GongJi = GameObject.Find("MyPlane").GetComponent<Inspector>().GongJi;
                Obj.GetComponent<Rigidbody2D>().isKinematic = true;
                FinalFadeOpacity = 0.5F;
            }

            Obj.name = P[i].Name;
            Obj.GetComponent<Inspector>().GongJi = P[i].GongJi;
            Obj.GetComponent<Inspector>().PlaneNameID = P[i].ModleObject.name;
            Obj.GetComponent<Inspector>().extraPricings = P[i].extraPricings;
            Obj.GetComponent<DiMove>().Road = P[i].Road;
            Obj.rotation = Quaternion.Euler(Obj.rotation.eulerAngles + new Vector3(0, 0, P[i].RotationRectify));
            Obj.gameObject.layer = P[i].Layer;
            Obj.position = P[i].Road.Points[0];
            Obj.GetComponent<Inspector>().ShengMing = P[i].ShengMing;
            if (P[i].Layer == 10)
            {
                string ID = (System.DateTime.Now - System.DateTime.MinValue).Ticks.ToString() + ((int)(Random.value * 1000)).ToString();
                Obj.GetComponent<Inspector>().ID = ID;
                PlanesID.Add(ID);
                foreach (GameObject G in Fade.GetAllChildGameObject(Obj))
                {
                    G.layer = P[i].Layer;
                }
                if (DifficultNum == 1)
                {
                    Obj.GetComponent<DiMove>().Velocity *= 0.8F;
                    if (Random.value < Fortune)
                    {
                        Obj.GetComponent<Inspector>().GongJi = (int)(Obj.GetComponent<Inspector>().GongJi * 0.8F);
                        Obj.GetComponent<Inspector>().ShengMing = new int[] { (int)(Obj.GetComponent<Inspector>().ShengMing[0] * 0.8F),
                        (int)(Obj.GetComponent<Inspector>().ShengMing[1] * 0.8F)};
                    }
                    if (Random.value < Fortune / 2 && Obj.GetComponent<Inspector>().ShengMing[1]
                        < GameObject.Find("MyPlane").GetComponent<Inspector>().ShengMing[1] * 5)
                    {
                        Obj.GetComponent<Inspector>().ShengMing = new int[] { (int)(Obj.GetComponent<Inspector>().ShengMing[0] * Random.value),
                        Obj.GetComponent<Inspector>().ShengMing[1]};
                    }
                }
                if (DifficultNum == 2)
                {
                    Obj.GetComponent<Inspector>().GongJi = (int)(Obj.GetComponent<Inspector>().GongJi * 1.25F);
                    Obj.GetComponent<Inspector>().ShengMing = new int[] { (int)(Obj.GetComponent<Inspector>().ShengMing[1] * 1.3F),
                        (int)(Obj.GetComponent<Inspector>().ShengMing[1] * 1.3F)};
                }
                if (DifficultNum == 3)
                {
                    Obj.GetComponent<DiMove>().Velocity *= 1.05F;
                    Obj.GetComponent<Inspector>().GongJi = (int)(Obj.GetComponent<Inspector>().GongJi * 2F);
                    Obj.GetComponent<Inspector>().ShengMing = new int[2] { (int)(Obj.GetComponent<Inspector>().ShengMing[1] * 2.25F),
                        (int)(Obj.GetComponent<Inspector>().ShengMing[1] * 2.25F)};
                }
            }
            else
            {
                Obj.rotation = Quaternion.Euler(Obj.rotation.eulerAngles + new Vector3(0, 0, 180 + P[i].RotationRectify));
                foreach (GameObject G in Fade.GetAllChildGameObject(Obj))
                {
                    G.layer = P[i].Layer;
                }
            }
            if (P[i].HuDun > 0 && Obj.transform.Find("HuDun"))
            {
                Obj.transform.Find("HuDun").transform.GetComponent<HuDun>().HuDunMaxShengMing = P[i].HuDun;
                Obj.transform.Find("HuDun").transform.GetComponent<HuDun>().HuDunShengMingNow = P[i].HuDun;
            }
            Fade.NewFade(Obj, 0, FinalFadeOpacity, 1, true);
            if (P[i].RecycleNum > 0)
            {
                P[i].RecycleNum--;
                i--;
            }
        }

        ShiLiBi *= 1 + Mathf.Pow(TCNum, 0.7F) / 25;
        if (GuanQiaChoosed == "T_1")
        {
            ShiLiBi /= 100;
        }
        if (GuanQiaChoosed == "T_3")
        {
            ShiLiBi /= 2.5F;
        }
        if (DifficultNum == 2)
        {
            ShiLiBi *= 1.2F;
        }
        if (DifficultNum == 3)
        {
            ShiLiBi *= 1.6F;
        }

        switch (PlanesMessage.ChuZhanPlane)
        {
            case "FS_1":
                ShiLiBi *= 1F;
                break;
            case "TU_1":
                ShiLiBi *= 1.02F;
                break;
            case "HZ_1":
                ShiLiBi *= 1.2F;
                break;
            case "BR_1":
                ShiLiBi *= 1F;
                break;
            case "FR_1":
                ShiLiBi *= 0.9F;
                break;
        }

        while (true)
        {
            yield return new WaitForFixedUpdate();

            if (!GuanQiaID.Contains(thisGuanQiaID))  // 如果当前关卡不存在（ID不在列表GuanQiaID中）
            {
                yield break;  // 结束关卡
            }

            if (PlanesID.Count == 0)
            {
                break;
            }
        }
        yield return new WaitForSeconds(1.5F);
        if (!HasFailed)
        {
            FinishGuanQia(GuanQiaChoosed, thisGuanQiaID);
        }
    }

    public static float Eval(string Str)
    {
        return Eval(Str, new Planes());
    }

    public static float Eval(string Str, object Class)
    {
        Str.Replace(" ", "");
        List<string> Str0 = new List<string>();
        string Str1 = "";
        for (int i = 0; i < Str.Length; i++)
        {
            if (Str[i] != '+' && Str[i] != '-' && Str[i] != '*' && Str[i] != '/' && Str[i] != '(' && Str[i] != ')' && Str[i] != '{' && Str[i] != '}')
            {
                Str1 += Str[i];
            }
            else
            {
                if (Str1 != "")
                {
                    Str0.Add(Str1);
                }
                Str0.Add(Str[i].ToString());
                Str1 = "";
            }
        }
        Str0.Add(Str1);

        #region 替换随机数
        for (int i = 0; i < Str0.Count; i++)
        {
            if (Str0[i] == "r")
            {
                Str0[i] = Random.value.ToString();
            }
        }
        #endregion

        #region 替换变量
        for (int i = 0; i < Str0.Count; i++)
        {
            if (Str0[i] == "{")
            {
                string Name = Str0[i + 1];
                Str0[i] = Class.GetType().GetField(Name).GetValue(Class).ToString();
                Str0.RemoveAt(i + 2);
                Str0.RemoveAt(i + 1);
            }
        }
        #endregion

        #region 括号运算
        for (int i = 0; i < Str0.Count; i++)
        {
            if (Str0[i] == "(")
            {
                int u;
                int Num = 0;
                for (u = i; u < Str0.Count; u++)
                {
                    if (Str0[u] == "(")
                    {
                        Num++;
                    }
                    if (Str0[u] == ")")
                    {
                        break;
                    }
                }
                for (; u < Str0.Count; u++)
                {
                    if (Str0[u] == ")")
                    {
                        Num--;
                        if (Num == 0)
                        {
                            break;
                        }
                    }
                }
                string ChildStr = "";
                for (int k = i + 1; k < u; k++)
                {
                    ChildStr += Str0[k];
                }
                for (int k = u - 1; k > i; k--)
                {
                    Str0.RemoveAt(k);
                }
                Str0[i] = Eval(ChildStr).ToString();
                Str0.RemoveAt(i + 1);

                ChildStr = "";
                for (int k = 0; k < Str0.Count; k++)
                {
                    ChildStr += Str0[k];
                }
            }
        }
        #endregion

        #region 乘除法运算
        for (int i = 0; i < Str0.Count; i++)
        {
            if (Str0[i] == "*")
            {
                Str0[i - 1] = (float.Parse(Str0[i - 1]) * float.Parse(Str0[i + 1])).ToString();
                Str0.RemoveAt(i + 1);
                Str0.RemoveAt(i);
                i--;
            }
            else if (Str0[i] == "/")
            {
                Str0[i - 1] = (float.Parse(Str0[i - 1]) / float.Parse(Str0[i + 1])).ToString();
                Str0.RemoveAt(i + 1);
                Str0.RemoveAt(i);
                i--;
            }
        }
        #endregion

        #region 加减法运算
        for (int i = 0; i < Str0.Count; i++)
        {
            if (Str0[i] == "+")
            {
                Str0[i - 1] = (float.Parse(Str0[i - 1]) + float.Parse(Str0[i + 1])).ToString();
                Str0.RemoveAt(i + 1);
                Str0.RemoveAt(i);
                i--;
            }
            else if (Str0[i] == "-")
            {
                Str0[i - 1] = (float.Parse(Str0[i - 1]) - float.Parse(Str0[i + 1])).ToString();
                Str0.RemoveAt(i + 1);
                Str0.RemoveAt(i);
                i--;
            }
        }
        #endregion

        return float.Parse(Str0[0]);
    }

    public static bool HasFailed = false;
    public static void FinishGuanQia(string GuanQiaName, string thisGuanQiaID, bool IsSuccess = true)
    {
        System.TimeSpan Dt = System.DateTime.Now - StartTime;
        if (IsSuccess && GuanQiaID.Count > 0)
        {
            GuanQiaChoosed = "";
            Fade.StringToTransform("Canvas/FinishGuanQia/Title").GetComponent<TextMeshProUGUI>().text = "胜利";
            Fade.StringToTransform("Canvas/FinishGuanQia/Title").GetComponent<TextMeshProUGUI>().color = new Color(0.2F, 0.69F, 0.67F);
            Fade.StringToTransform("Canvas/FinishGuanQia/Background/Image0").GetComponent<Image>().color = new Color(0.21F, 0.58F, 0.64F);
            Fade.StringToTransform("Canvas/FinishGuanQia/Background/Image1").GetComponent<Image>().color = new Color(0.18F, 0.54F, 0.59F, 0.4F);
            Fade.StringToTransform("Canvas/FinishGuanQia/Background/Image2").GetComponent<Image>().color = new Color(0.18F, 0.43F, 0.59F);
            Fade.StringToTransform("Canvas/FinishGuanQia/Background").GetComponent<Image>().color = new Color(0.16F, 0.30F, 0.29F);
            for (int i = 0; i < Fade.StringToTransform("Canvas/FinishGuanQia").childCount; i++)
            {
                if (Fade.StringToTransform("Canvas/FinishGuanQia").GetChild(i).GetComponent<TextMeshProUGUI>()
                    && Fade.StringToTransform("Canvas/FinishGuanQia").GetChild(i).name != "Title"
                    && Fade.StringToTransform("Canvas/FinishGuanQia").GetChild(i).name != "Grade")
                {
                    Fade.StringToTransform("Canvas/FinishGuanQia").GetChild(i).GetComponent<TextMeshProUGUI>().color = new Color(0.16F, 0.57F, 0.73F);
                }
            }
            Delegates();
            Delegates = null;
            Fortune *= 0.3F;
        }
        else
        {
            GuanQiaID.Clear();  // 注销当前所有关卡
            Fade.StringToTransform("Canvas/FinishGuanQia/Title").GetComponent<TextMeshProUGUI>().text = "失败";
            Fade.StringToTransform("Canvas/FinishGuanQia/Title").GetComponent<TextMeshProUGUI>().color = new Color(0.7F, 0.2F, 0.2F);
            Fade.StringToTransform("Canvas/FinishGuanQia/Background/Image0").GetComponent<Image>().color = new Color(0.64F, 0.24F, 0.21F);
            Fade.StringToTransform("Canvas/FinishGuanQia/Background/Image1").GetComponent<Image>().color = new Color(0.64F, 0.23F, 0.28F, 0.4F);
            Fade.StringToTransform("Canvas/FinishGuanQia/Background/Image2").GetComponent<Image>().color = new Color(0.64F, 0.4F, 0.23F);
            Fade.StringToTransform("Canvas/FinishGuanQia/Background").GetComponent<Image>().color = new Color(0.31F, 0.17F, 0.16F);
            for (int i = 0; i < Fade.StringToTransform("Canvas/FinishGuanQia").childCount; i++)
            {
                if (Fade.StringToTransform("Canvas/FinishGuanQia").GetChild(i).GetComponent<TextMeshProUGUI>()
                    && Fade.StringToTransform("Canvas/FinishGuanQia").GetChild(i).name != "Title"
                    && Fade.StringToTransform("Canvas/FinishGuanQia").GetChild(i).name != "Grade")
                {
                    Fade.StringToTransform("Canvas/FinishGuanQia").GetChild(i).GetComponent<TextMeshProUGUI>().color = new Color(0.75F, 0.37F, 0.30F);
                }
            }
            Fortune += Random.value * 0.15F - 0.05F;
        }
        if (MyPlane.TotalBulletUse == 0)
        {
            MyPlane.TotalBulletUse += 1;
        }
        string DtStr = "";
        if (Dt.Hours > 0) { DtStr += Dt.Hours + "时"; }
        if (Dt.Minutes > 0) { DtStr += Dt.Minutes + "分"; }
        DtStr += Dt.Seconds + "秒";
        string ShiLiBiStr = "<color=#D4D4D4>" + ShiLiBi.ToString("#0.00") + "</color>";
        if (ShiLiBi > 100)
        {
            ShiLiBiStr = "<color=#D26E6E>>100</color>";
        }
        if (ShiLiBi < 0.05)
        {
            ShiLiBiStr = "<color=#48E380><0.05</color>";
        }
        if (ShiLiBi < 0.97)
        {
            ShiLiBiStr = ShiLiBiStr.Replace("D4D4D4", "48E380");
        }
        if (ShiLiBi > 1.05)
        {
            ShiLiBiStr = ShiLiBiStr.Replace("D4D4D4", "D26E6E");
        }
        if (IsSkip)
        {
            ShiLiBiStr = "<color=#a8a8a8>--</color>";
        }
        float Grade = 0;
        string GradeStr = "";
        Grade += 50 + Mathf.Pow((float)MyPlane.TotalBulletHit / MyPlane.TotalBulletUse, 2) * 50 + Mathf.Pow(MyPlane.TotalBulletHit, 0.5F) * 0.3F;
        if (ShiLiBi < 1 && CheckDiPass.DiPass == 0 && MyPlane.MyPlaneWasHit == 0 && IsSuccess)
        {
            Grade /= ShiLiBi;
        }
        else if (CheckDiPass.DiPass == 0 && IsSuccess && ShiLiBi >= 1)
        {
            Grade *= ShiLiBi;
        }
        if (!IsSuccess)
        {
            Grade -= 50;
        }
        Grade -= CheckDiPass.DiPass * 30;
        Grade -= MyPlane.MyPlaneWasHit * 2.5F;
        if (Grade >= 85)
        {
            GradeStr = "<color=#FFB53D>尊</color>";
        }
        if (Grade >= 70 && Grade < 85)
        {
            GradeStr = "<color=#C57CFF>甲</color>";
        }
        if (Grade >= 50 && Grade < 70)
        {
            GradeStr = "<color=#63ABF3>乙</color>";
        }
        if (Grade >= 30 && Grade < 50)
        {
            GradeStr = "<color=#499377>丙</color>";
        }
        if (Grade < 30 || IsSkip)
        {
            GradeStr = "<color=#6A6A6A>丁</color>";
        }

        Fade.StringToTransform("Canvas/FinishGuanQia/Grade").GetComponent<TextMeshProUGUI>().text = GradeStr;
        Fade.StringToTransform("Canvas/FinishGuanQia/MingZhongPercent").GetComponent<TextMeshProUGUI>().text = "命中率："
            + "<color=#D4D4D4>" + (float)((int)((float)MyPlane.TotalBulletHit / MyPlane.TotalBulletUse * 1000) / 10) + " %" + "</color>";
        Fade.StringToTransform("Canvas/FinishGuanQia/MingZhongNum").GetComponent<TextMeshProUGUI>().text = "命中数："
            + "<color=#D4D4D4>" + MyPlane.TotalBulletHit + "</color><color=#424242> / " + MyPlane.TotalBulletUse + "</color>";
        Fade.StringToTransform("Canvas/FinishGuanQia/BeiMingZhongNum").GetComponent<TextMeshProUGUI>().text = "被命中："
            + "<color=#D4D4D4>" + MyPlane.MyPlaneWasHit + " 次" + "</color>";
        Fade.StringToTransform("Canvas/FinishGuanQia/YongShi").GetComponent<TextMeshProUGUI>().text = "用时："
            + "<color=#D4D4D4>" + DtStr + "</color>";
        Fade.StringToTransform("Canvas/FinishGuanQia/DiRenTongGuo").GetComponent<TextMeshProUGUI>().text = "敌人通过："
            + ("<color=#CD6060>" + CheckDiPass.DiPass + "</color>").Replace("<color=#CD6060>0</color>", "<color=#D4D4D4>0</color>");
        Fade.StringToTransform("Canvas/FinishGuanQia/JiHui").GetComponent<TextMeshProUGUI>().text = "击毁："
            + "<color=#D4D4D4>" + MyPlane.DestroyDiPlane + "</color>";
        Fade.StringToTransform("Canvas/FinishGuanQia/ShiLiBi").GetComponent<TextMeshProUGUI>().text = "实力比："
            + ShiLiBiStr;
        Fade.StringToTransform("Canvas/FinishGuanQia/GuanQia").GetComponent<TextMeshProUGUI>().text = "关卡："
            + "<color=#D4D4D4>" + GuanQiaName.Replace("SuiPian_", "碎片获取 ").Replace("_", "-") + "</color>";
        if (IsSuccess)
        {
            int Grade1 = int.Parse(GradeStr.Split('>')[1].Split('<')[0].Replace("尊", "5")
                .Replace("甲", "3").Replace("乙", "2").Replace("丙", "1").Replace("丁", "0"));
            string SaveStr = "";
            bool HasOldPassRecord = false;
            if (GuanQiaNanDuChoosed == 1 || IsSkip)
            {
                SaveStr = GuanQiaName + "=I=" + GradeStr.Split('>')[1].Split('<')[0];
            }
            if (GuanQiaNanDuChoosed == 2)
            {
                SaveStr = GuanQiaName + "=II=" + GradeStr.Split('>')[1].Split('<')[0];
            }
            if (GuanQiaNanDuChoosed == 3)
            {
                SaveStr = GuanQiaName + "=III=" + GradeStr.Split('>')[1].Split('<')[0];
            }
            foreach (string S in ControlCenter.FinishedAppendGuanQiaAppendMessage)
            {
                if (S.Split('=')[0] + "=" + S.Split('=')[1] == SaveStr.Split('=')[0] + "=" + SaveStr.Split('=')[1])
                {
                    int GradeS = int.Parse(S.Split('=')[2].Replace("尊", "5")
                    .Replace("甲", "3").Replace("乙", "2").Replace("丙", "1").Replace("丁", "0"));
                    HasOldPassRecord = true;
                    if (Grade1 > GradeS)
                    {
                        ControlCenter.FinishedAppendGuanQiaAppendMessage.Remove(S);
                        ControlCenter.FinishedAppendGuanQiaAppendMessage.Add(SaveStr);
                        break;
                    }
                }
            }
            if (!HasOldPassRecord)
            {
                ControlCenter.FinishedAppendGuanQiaAppendMessage.Add(SaveStr);
            }
            ReloadMap();
            SaveCouldStartMap();
        }

        Fade.NewFade("Canvas/FinishGuanQia", 0, 1, 0.6F);
        GuanQiaID.Remove(thisGuanQiaID);
        Weapon.StopAll();
        for (int i = 0; i < GameObject.Find("Space").transform.childCount; i++)
        {
            if (GameObject.Find("Space").transform.GetChild(i))
            {
                Destroy(GameObject.Find("Space").transform.GetChild(i).gameObject);
            }
        }
        for (int i = 0; i < GameObject.Find("Space").transform.childCount; i++)
        {
            if (GameObject.Find("Space").transform.GetChild(i))
            {
                Destroy(GameObject.Find("Space").transform.GetChild(i).gameObject);
            }
        }
        IsZhanDou = false;
        if (OnUpdate.MyHuDun)
        {
            OnUpdate.MyHuDun.StartCoroutine(newMyHuDun());
        }
        ResetCamera();
    }

    static IEnumerator newMyHuDun()
    {
        yield return new WaitForSeconds(1.5F);
        if (!OnUpdate.MyHuDun.IsHuDunExist)
        {
            OnUpdate.MyHuDun.CreateNewHuDun(1);
        }
    }

    static void MyHuDunRecover()
    {
        if (!OnUpdate.MyHuDun.IsHuDunExist)
        {
            OnUpdate.MyHuDun.CreateNewHuDun();
        }
    }

    static void ResetCamera()
    {
        GameObject.Find("MainCamera").GetComponent<Camera>().orthographicSize = 5.25F;
        GameObject.Find("MainCamera").transform.position = new Vector3(0, 0, -10);
    }

    public static void ReloadMap()
    {
        foreach (string S in ControlCenter.CouldStartGuanQia)
        {
            if (int.TryParse(S.Split('_')[0], out _))
            {
                Fade.StringToTransform("Canvas/Map/" + S.Split('_')[0] + "/" + S).GetComponent<Image>().color = new Color(0.18F, 0.72F, 0.94F, 0.6F);
            }
            if (S.Split('_')[0] == "T")
            {
                foreach (string Tra in Fade.GetAllChild(Fade.StringToTransform("Canvas/Map")))
                {
                    if (Fade.StringToTransform(Tra).name == S && Fade.StringToTransform(Tra).tag == "ChooseGuanQia")
                    {
                        Fade.StringToTransform(Tra).GetComponent<Image>().color = new Color(0.14F, 1F, 0.72F, 0.6F);
                    }
                }
            }
            if (!ControlCenter.FinishedGuanQia.Contains(S))
            {
                foreach (string Tra in Fade.GetAllChild(Fade.StringToTransform("Canvas/Map")))
                {
                    if (Fade.StringToTransform(Tra).name == S && Fade.StringToTransform(Tra).tag == "ChooseGuanQia")
                    {
                        if (!Fade.StringToTransform(Tra).transform.Find("Sign_Jian"))
                        {
                            Transform Obj = Instantiate(Fade.StringToTransform("Canvas/Map/Sign_Jian"), Fade.StringToTransform(Tra));
                            Obj.localScale = Vector3.one;
                            Obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -50);
                            Obj.transform.Find("Sign_Jian").GetComponent<Image>().color = Fade.StringToTransform(Tra).GetComponent<Image>().color;
                            Obj.name = "Sign_Jian";
                            Obj.gameObject.SetActive(true);
                        }
                    }
                }
            }
            else
            {
                foreach (string Tra in Fade.GetAllChild(Fade.StringToTransform("Canvas/Map")))
                {
                    if (Fade.StringToTransform(Tra).name == S && Fade.StringToTransform(Tra).tag == "ChooseGuanQia")
                    {
                        if (Fade.StringToTransform(Tra).transform.Find("Sign_Jian"))
                        {
                            Destroy(Fade.StringToTransform(Tra).transform.Find("Sign_Jian").gameObject);
                        }
                    }
                }
            }
        }
        foreach (string S in ControlCenter.FinishedAppendGuanQiaAppendMessage)
        {
            Color Col = ChangeColorAndHex.Colors.RareNumToRareColor(int.Parse(S.Split('=')[2]
                .Replace("丁", "0").Replace("丙", "1").Replace("乙", "2").Replace("甲", "3").Replace("尊", "4")));
            string MapFileP = S.Split('=')[0].Replace("T_1", "1").Replace("T_2", "1").Replace("T_3", "1");
            MapFileP = MapFileP.Split('_')[0].Replace("SuiPian", "0");
            Fade.StringToTransform("Canvas/Map/" + MapFileP + "/"
                + S.Split('=')[0] + "/PassState/" + S.Split('=')[1]).GetComponent<Image>().color = Col;
        }
    }

    public static void SaveCouldStartMap()
    {
        int N = 0;
        string L = "";
        foreach(string S in ControlCenter.CouldStartGuanQia)
        {
            L += "<" + N + ">" + S + "</" + N + ">";
            N++;
        }
        Save.SetString("CouldStartGuanQia", L);

        N = 0;
        L = "";
        foreach (string S in ControlCenter.FinishedGuanQia)
        {
            L += "<" + N + ">" + S + "</" + N + ">";
            N++;
        }
        Save.SetString("FinishedGuanQia", L);

        N = 0;
        L = "";
        foreach (string S in ControlCenter.FinishedAppendGuanQiaAppendMessage)
        {
            L += "<" + N + ">" + S + "</" + N + ">";
            N++;
        }
        Save.SetString("FinishedAppendGuanQiaAppendMessage", L);
    }
}

public class Planes
{
    public BezierEquation Road = new BezierEquation(new Vector2[] { new Vector2(0, 8) });
    public string[] RandomRoad = new string[] { };
    public string Name = "";
    public int[] ShengMing = new int[] { 100, 100 };
    public int GongJi = 20;
    public int HuDun = 0;
    public Transform ModleObject;
    public float DuringTime = 1;
    public string RandomDuringTime = "";
    [Tooltip("9：己方阵营   10：敌方阵营")]
    public int Layer = 10;
    public float RotationRectify = 0;

    [Tooltip("循环放置此物体次数\n<=0：不循环  >0：循环次数\n（共放置了{RecycleNum}+1 架战机）")]
    public int RecycleNum = 0;
    public List<ExtraPricing> extraPricings = new List<ExtraPricing>();
}