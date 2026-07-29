package com.utp.sistemas.controllers;

import com.utp.sistemas.dtos.LoginRequest;
import com.utp.sistemas.entities.Empleado;
import com.utp.sistemas.repositories.EmpleadoRepository;
import io.jsonwebtoken.Jwts;
import io.jsonwebtoken.SignatureAlgorithm;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.Date;
import java.util.HashMap;
import java.util.Map;
import java.util.Optional;

@RestController
@RequestMapping("/api/auth")
public class UsuarioController {

    private final EmpleadoRepository empleadoRepository;

    @Value("${jwt.secret}")
    private String jwtSecret;

    @Value("${jwt.expirationMs}")
    private long jwtExpirationMs;

    public UsuarioController(EmpleadoRepository empleadoRepository) {
        this.empleadoRepository = empleadoRepository;
    }

    @PostMapping("/login")
    public ResponseEntity<?> login(@RequestBody LoginRequest request) {
        Optional<Empleado> empleadoOpt = empleadoRepository.findByUsuarioAndClave(
                request.getUsuario(), request.getClave());

        if (empleadoOpt.isEmpty()) {
            return ResponseEntity.status(401).body("Credenciales inválidas");
        }

        //String token = generateJwtToken(empleadoOpt.get().getUsuario());

//        Map<String, String> response = new HashMap<>();
//        response.put("token", token);

        return ResponseEntity.ok(empleadoOpt);
    }


//    private String generateJwtToken(String username) {
//        Date now = new Date();
//        Date expiryDate = new Date(now.getTime() + jwtExpirationMs);
//
//        return Jwts.builder()
//                .setSubject(username)
//                .setIssuedAt(now)
//                .setExpiration(expiryDate)
//                .signWith(SignatureAlgorithm.HS512, jwtSecret)
//                .compact();
//    }
}
