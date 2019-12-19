<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ page import = "java.sql.*" %>
<%
	Connection conn = null;
	PreparedStatement pstmt = null;
	ResultSet rs = null;
	
	try{
		Class.forName("com.mysql.jdbc.Driver");
	String url = "jdbc:mysql://localhost:3306/rabbitgame";
	String user = "root";
	String userpw = "1234";
		conn=DriverManager.getConnection(url,user,userpw);
		
		// 여기는 발표 후 수정한 부분입니다. sql문뒤에 where 조건으로 정렬을 단순화했습니다. 이런 간단한 방법이ㅠㅠ
		String sql = "select * from ranking order by score desc";
		pstmt = conn.prepareStatement(sql);
		rs = pstmt.executeQuery();
		while(rs.next()){
			String order = rs.getString("order");
			String name = rs.getString("name");
			String score = rs.getString("score");
			String datetime = rs.getString("datetime");
			out.println(order+"&"+name+"&"+score+"&"+datetime+"#");
		} 
	
	}catch(Exception e){ 
	
		e.printStackTrace();
		out.println("Fail");
	
	}finally{
	
		if(rs != null) try{rs.close();}catch(SQLException sqle){}
		if(pstmt != null) try{pstmt.close();}catch(SQLException sqle){}
		if(conn != null) try{conn.close();}catch(SQLException sqle){} 
	
	}
%>
