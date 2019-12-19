<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ page import = "java.sql.*" %>
<%
	request.setCharacterEncoding("utf-8");

	String name= request.getParameter("name");
	String score = request.getParameter("score");
	String datetime = request.getParameter("datetime");
	
	Connection conn = null;
	PreparedStatement pstmt = null;
	
	try{
		Class.forName("com.mysql.jdbc.Driver");
		String url = "jdbc:mysql://localhost:3306/rabbitgame";
		String user = "root";
		String userpw = "1234";
		
		conn=DriverManager.getConnection(url,user,userpw);
		
		String sql = "insert into ranking (name, score, datetime) values(?,?,?)";
		
		pstmt = conn.prepareStatement(sql);
		
		pstmt.setString(1,name);
		pstmt.setString(2,score);
		pstmt.setString(3,datetime);
		pstmt.executeUpdate();
	}catch(Exception e){
		e.printStackTrace();
		out.println("실패");
	}finally {
		if(pstmt != null) try{pstmt.close();}catch(SQLException sqle){}
		if(conn != null) try{conn.close();}catch(SQLException sqle){}
	}
%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Insert title here</title>
<script type="text/javascript">
</script>
</head>
<body>

</body>
</html>