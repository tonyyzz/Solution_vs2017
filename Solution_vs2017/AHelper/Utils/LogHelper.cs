﻿using System;
using log4net;

namespace Auction.Utility.Utils
{
	/// <summary>
	/// 
	/// </summary>
	public class LogUtils
	{
		private static readonly ILog logger = LogManager.GetLogger(typeof(LogUtils));

		/// <summary>
		/// 
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="e"></param>
		public static void WriteFatal(string msg, Exception e = null)
		{
			logger.Fatal(msg, e);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="e"></param>
		public static void WriteError(string msg, Exception e = null)
		{
			logger.Error(msg, e);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="e"></param>
		public static void WriteLog(string msg, Exception e = null)
		{
			logger.Info(msg, e);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="e"></param>
		public static void WritDebug(string msg, Exception e = null)
		{
			logger.Debug(msg, e);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="e"></param>
		public static void WritWarn(string msg, Exception e = null)
		{
			logger.Warn(msg, e);
		}

		/*
		 在webconfig的configuration节点下添加以下配置项，并在网站启动时添加代码：log4net.Config.XmlConfigurator.Configure();

	<!--log4net此节点和section节点里的配置是log4net的，还要startup.cs里的 log4net.Config.XmlConfigurator.Configure(); 都是必要的-->
	<log4net>
		<root>
			<level value="ALL" />
			<appender-ref ref="FatalAppender" />
			<appender-ref ref="ErrorAppender" />
			<appender-ref ref="WarnAppender" />
			<appender-ref ref="InfoAppender" />
			<appender-ref ref="DebugAppender" />
			<appender-ref ref="aiAppender" />
		</root>

		<!--这个只记录FATAL级别的日志信息，记录到fatal.txt文件中。-->
		<appender name="FatalAppender" type="log4net.Appender.FileAppender">
			<file value="CustomLog/fatal.txt" />
			<appendToFile value="false" />
			<rollingStyle value="Date" />
			<datePattern value="yyyyMMdd-HH:mm:ss" />
			<layout type="log4net.Layout.PatternLayout">
				<conversionPattern value="&#xD;记录时间：%date 日志级别：%-5level 行号 : %line - 描述：%message%newline" />
			</layout>
			<filter type="log4net.Filter.LevelRangeFilter">
				<levelMin value="FATAL" />
				<levelMax value="FATAL" />
			</filter>
		</appender>

		<!--这个只记录ERROR级别的日志信息，记录到error.txt文件中。-->
		<appender name="ErrorAppender" type="log4net.Appender.FileAppender">
			<file value="CustomLog/error.txt" />
			<appendToFile value="false" />
			<rollingStyle value="Date" />
			<datePattern value="yyyyMMdd-HH:mm:ss" />
			<layout type="log4net.Layout.PatternLayout">
				<conversionPattern value="&#xD;记录时间：%date 日志级别：%-5level 行号 : %line - 描述：%message%newline" />
			</layout>
			<filter type="log4net.Filter.LevelRangeFilter">
				<levelMin value="ERROR" />
				<levelMax value="ERROR" />
			</filter>
		</appender>

		<!--这个只记录WARN别的日志信息，记录到warn.txt文件中。-->
		<appender name="WarnAppender" type="log4net.Appender.FileAppender">
			<file value="CustomLog/warn.txt" />
			<appendToFile value="false" />
			<rollingStyle value="Hour" />
			<datePattern value="yyyyMMdd-HH:mm:ss" />
			<layout type="log4net.Layout.PatternLayout">
				<conversionPattern value="&#xD;记录时间：%date 日志级别：%-5level 行号 : %line - 描述：%message%newline" />
			</layout>
			<filter type="log4net.Filter.LevelRangeFilter">
				<levelMin value="WARN" />
				<levelMax value="WARN" />
			</filter>
		</appender>

		<!--这个只记录log级别的日志信息，记录到log.txt文件中。-->
		<appender name="InfoAppender" type="log4net.Appender.FileAppender">
			<file value="CustomLog/log.txt" />
			<appendToFile value="false" />
			<rollingStyle value="Size" />
			<maxSizeRollBackups value="0" />
			<staticLogFileName value="true" />
			<datePattern value="yyyyMMdd-HH:mm:ss" />
			<layout type="log4net.Layout.PatternLayout">
				<conversionPattern value="&#xD;记录时间：%date 日志级别：%-5level 行号 : %line - 描述：%message%newline" />
			</layout>
			<filter type="log4net.Filter.LevelRangeFilter">
				<levelMin value="INFO" />
				<levelMax value="INFO" />
			</filter>
		</appender>


		<!--这个只记录debug级别的日志信息，记录到debug.txt文件中。-->
		<appender name="DebugAppender" type="log4net.Appender.FileAppender">
			<file value="CustomLog/debug.txt" />
			<appendToFile value="false" />
			<rollingStyle value="Hour" />
			<datePattern value="yyyyMMdd-HH:mm:ss" />
			<layout type="log4net.Layout.PatternLayout">
				<conversionPattern value="&#xD;记录时间：%date 日志级别：%-5level 行号 : %line - 描述：%message%newline" />
			</layout>
			<filter type="log4net.Filter.LevelRangeFilter">
				<levelMin value="DEBUG" />
				<levelMax value="DEBUG" />
			</filter>
		</appender>
		<appender name="aiAppender" type="Microsoft.ApplicationInsights.Log4NetAppender.ApplicationInsightsAppender, Microsoft.ApplicationInsights.Log4NetAppender">
			<layout type="log4net.Layout.PatternLayout">
				<conversionPattern value="%message%newline" />
			</layout>
		</appender>

	</log4net>

		 */
	}

}