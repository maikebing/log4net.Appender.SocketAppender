# SocketAppender  Readme 

Config in code:
` log4net.GlobalContext.Properties["HostIP"] = System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName()).FirstOrDefault(a => a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToString(); `
` log4net.GlobalContext.Properties["Version"] = System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString(4); `
` log4net.GlobalContext.Properties["AppName"] = System.Reflection.Assembly.GetEntryAssembly().GetName().Name; `
` log4net.GlobalContext.Properties["AppFullName"] = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description; `

Config in Xml  

`
`  <appender name="SocketAppender" type="log4net.Appender.SocketAppender,log4net.Appender.SocketAppender"> `
`    <RemoteAddress value="127.0.0.1" /> `
`    <RemotePort value="5001" /> `
`    <AddressFamily value="InterNetwork" /> `
`    <SocketType value="Dgram" /> `
`    <ProtocolType value="Udp" />
`    <ConAttemptsCount value="5" /> `
`    <ConAttemptsWaitingTimeMilliSeconds value="3000" /> `
`    <UseThreadPoolQueue value="true" /> `
`    <layout type="log4net.Layout.PatternLayout, log4net"> `
`      <conversionPattern value="{&quot;LogType&quot;:&quot;IoTHub.Log&quot;,&quot;AppName&quot;:&quot;%property{AppName}&quot;,&quot;AppFullName&quot;:&quot;%property{AppFullName}&quot;,&quot;Version&quot;:&quot;%property{Version}&quot;&quot;host&quot;:&quot;%property{HostIP}&quot;,&quot;LogLevel&quot;:&quot;%level&quot;,&quot;@timestamp&quot;:&quot;%date{ISO8601}&quot;,&quot;Logger&quot;:&quot;%logger&quot;,&quot;message&quot;:&quot;%message&quot;}" /> `

`    </layout>
`  </appender>
