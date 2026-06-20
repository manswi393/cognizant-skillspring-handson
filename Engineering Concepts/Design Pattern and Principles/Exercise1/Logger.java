public class Logger {

    // 1. Private static instance (single object)
    private static Logger instance;

    // 2. Private constructor (prevents object creation)
    private Logger() {
        System.out.println("Logger instance created");
    }

    // 3. Public method to provide access to the single instance
    public static Logger getInstance() {
        if (instance == null) {
            instance = new Logger(); // lazy initialization
        }
        return instance;
    }

    // Sample method to test logging
    public void log(String message) {
        System.out.println("LOG: " + message);
    }
}