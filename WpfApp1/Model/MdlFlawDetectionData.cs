using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace WpfApp1.Model
{
    public class MdlFlawDetectionData
    {

        public MdlFlawDetectionData(int num, bool isSelect1, string completedTime, string analyst1, string analystId1,string fileName)
        {
            Num = num;
            isSelect = isSelect1;
            analysisCompletedTime = completedTime;
            analyst = analyst1;
            analystId = analystId1;
            OriginalFileName = fileName;
        }
        /// <summary>
        /// 序号
        /// </summary>
        public int Num { get; set; }
        private bool isSelect { get; set; }
        /// <summary>
        /// 软件完成分析时间(yyyy-MM-dd HH:mm:ss)
        /// </summary>
        private string analysisCompletedTime { get; set; }
        /// <summary>
        /// 分析员
        /// </summary>
        private string analyst { get; set; }
        /// <summary>
        /// 分析员编号
        /// </summary>
        private string analystId { get; set; }
        /// <summary>
        /// 算法版本
        /// </summary>
        private string arithmeticVersion;
        /// <summary>
        /// 作业总量(米块表记录数)
        /// </summary>
        private int blockQuantity;
        /// <summary>
        /// 车型(LEFT.左手车 RIGHT.右手车),可用值:LEFT,RIGHT
        /// </summary>
        private string carType;
        /// <summary>
        /// 已回放伤损数
        /// </summary>
        private int checkFlawQuantity;
        /// <summary>
        /// 上传的数据类型(NORMAL(普通)、LEARN(学习)、REVIEW(复查)),可用值:NORMAL,LEARN,REVIEW
        /// </summary>
        private string dataType;
        /// <summary>
        /// 数据版本
        /// </summary>
        private string dataVersion;
        /// <summary>
        /// 作业方向(POSITIVE.顺里程 REVERSE.逆里程),可用值:POSITIVE,REVERSE
        /// </summary>
        private string direction;
        /// <summary>
        /// 目录编号(存放本次探伤作业的目录编号)
        /// </summary>
        private string directoryId;
        /// <summary>
        /// 导出时间(yyyy-MM-dd HH:mm:ss)
        /// </summary>
        private string exportTime;
        /// <summary>
        /// 伤损数量
        /// </summary>
        private int flawQuantity;
        /// <summary>
        /// 现场已判伤损数量
        /// </summary>
        private int flawSiteQuantity;
        /// <summary>
        /// fpga Version
        /// </summary>
        private string fpgaVersion;
        /// <summary>
        /// 大门设置
        /// </summary>
        private string gateSetting;
        /// <summary>
        /// 股别(YG(右股),ZG(左股)),可用值:YG,ZG
        /// </summary>
        private string gubie;
        /// <summary>
        /// id
        /// </summary>
        private string id;
        /// <summary>
        /// 是否已提交
        /// </summary>
        private bool submit;
        /// <summary>
        /// 名称(小车推出来的文件名，与目录名一致)
        /// </summary>
        private string OriginalFileName { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        private string principal;
        /// <summary>
        /// 负责人编号
        /// </summary>
        private string principalId;
        /// <summary>
        /// 探头角度
        /// </summary>
        private string probeAngle;
        /// <summary>
        /// 探头位置
        /// </summary>
        private string probePlace;
        /// <summary>
        /// 探头零点
        /// </summary>
        private string probeZeroPoint;
        /// <summary>
        /// 线编号
        /// </summary>
        private string railwayLineId;
        /// <summary>
        /// 线名
        /// </summary>
        private string railwayLineName;
        /// <summary>
        /// 车站编号
        /// </summary>
        private string railwayStationId;
        /// <summary>
        /// 车站名
        /// </summary>
        private string railwayStationName;
        /// <summary>
        /// 回放完成时间(yyyy-MM-dd HH:mm:ss)
        /// </summary>
        private string replayCompletedTime;
        /// <summary>
        /// 回放状态(NEVER.未回放 PART.部分回放 COMPLETE.完全回放),可用值:NEVER,PART,COMPLETE
        /// </summary>
        private string replayStatus;
        /// <summary>
        /// 复查单数量
        /// </summary>
        private int reviewOrderQuantity;
        /// <summary>
        /// 软件版本
        /// </summary>
        private string softwareVersion;
        /// <summary>
        /// 总步进
        /// </summary>
        private int totalStep;
        private int upload;
        /// <summary>
        /// 上传时间(yyyy-MM-dd HH:mm:ss)
        /// </summary>
        private string uploadTime;
        /// <summary>
        /// 上传人
        /// </summary>
        private string uploader;
        /// <summary>
        /// 上传人编号
        /// </summary>
        private string uploaderId;
        /// <summary>
        /// 作业结束里程
        /// </summary>
        private double workEndMileage;
        /// <summary>
        /// 作业结束里程
        /// </summary>
        private string workEndMileageName;
        /// <summary>
        /// 作业结束时间(yyyy-MM-dd)
        /// </summary>
        private string workEndTimeDesc;
        /// <summary>
        /// 作业结束时间(yyyy-MM-dd HH:mm:ss)
        /// </summary>
        private DateTime workEndTime;
        /// <summary>
        /// 作业班组
        /// </summary>
        private string workGroup;
        /// <summary>
        /// 作业长度
        /// </summary>
        private double workMileage;
        /// <summary>
        /// 工务段编号
        /// </summary>
        private string workSectionId;
        /// <summary>
        /// 工务段名称
        /// </summary>
        private string workSectionName;
        /// <summary>
        /// 作业开始里程
        /// </summary>
        private double workStartMileage;
        /// <summary>
        /// 作业开始里程
        /// </summary>
        private string workStartMileageName;
        /// <summary>
        /// 作业开始时间(yyyy-MM-dd)
        /// </summary>
        private string workStartTimeDesc;
        /// <summary>
        /// 作业开始时间(yyyy-MM-dd HH:mm:ss)
        /// </summary>
        private DateTime workStartTime;
        /// <summary>
        /// 工区
        /// </summary>
        private string workZone;
        /// <summary>
        /// 线别(ZX(正线),DFX(到发线),QTZX(其他站线)),可用值:ZX,ZHAN,DFX,QTZX
        /// </summary>
        private string xianbie;
        /// <summary>
        /// 行别(D(单线),S(上行),X(下行)),可用值:D,S,X,S2,S3,S4,S5,ZYX
        /// </summary>
        private string xingbie;

        private Visibility newVisibility;

        private String originalFolderName;
        /// <summary>
        /// 是否在上传中
        /// </summary>
        private bool isUploading;
        /// <summary>
        /// 上传、下载、修正状态按钮
        /// </summary>
        private string uploadStatus;

        /// <summary>
        /// 学习文件备注
        /// </summary>
        private string remark;

        private Visibility remarkVisibility = Visibility.Collapsed;


    }
}
