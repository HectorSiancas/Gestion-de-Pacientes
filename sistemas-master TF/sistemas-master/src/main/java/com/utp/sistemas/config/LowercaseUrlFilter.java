package com.utp.sistemas.config;

import jakarta.servlet.*;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletRequestWrapper;
import jakarta.servlet.http.HttpServletResponse;
import org.springframework.core.annotation.Order;
import org.springframework.stereotype.Component;

import java.io.IOException;

@Component
@Order(1) // Asegura que se ejecute antes que los filtros de Spring Security
public class LowercaseUrlFilter implements Filter {
    @Override
    public void doFilter(ServletRequest request, ServletResponse response, FilterChain chain)
            throws IOException, ServletException {

        HttpServletRequest httpRequest = (HttpServletRequest) request;

        // Solo convertir a minúscula si la URI tiene mayúsculas
        if (!httpRequest.getRequestURI().equals(httpRequest.getRequestURI().toLowerCase())) {
            // Envolver el request para modificar su comportamiento
            HttpServletRequestWrapper wrapper = new HttpServletRequestWrapper(httpRequest) {
                @Override
                public String getRequestURI() {
                    return httpRequest.getRequestURI().toLowerCase();
                }

                @Override
                public String getServletPath() {
                    return httpRequest.getServletPath().toLowerCase();
                }
            };

            chain.doFilter(wrapper, response);
        } else {
            chain.doFilter(request, response);
        }
    }
}
