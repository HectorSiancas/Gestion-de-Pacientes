package com.utp.sistemas.dtos;

import lombok.Data;

@Data
public class LoginRequest {
    private String usuario;
    private String clave;
}
