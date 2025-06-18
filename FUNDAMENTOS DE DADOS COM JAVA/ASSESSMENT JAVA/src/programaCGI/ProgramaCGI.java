package programaCGI;

public class ProgramaCGI {
	

	    public static void main(String[] args) {
	        // Header HTTP obrigatório
	        System.out.println("Content-Type: text/html");
	        
	        // Linha em branco obrigatória entre headers e corpo
	        System.out.println();
	        
	        // Corpo da resposta em HTML
	        System.out.println("<html>");
	        System.out.println("<head><title>Saudação CGI</title></head>");
	        System.out.println("<body>");
	        System.out.println("<h1>Olá, Terráqueos!</h1>");
	        System.out.println("</body>");
	        System.out.println("</html>");
	    }
	}


