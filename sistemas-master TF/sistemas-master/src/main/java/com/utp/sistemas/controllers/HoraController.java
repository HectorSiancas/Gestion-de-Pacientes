package com.utp.sistemas.controllers;

import com.utp.sistemas.entities.Hora;
import com.utp.sistemas.services.HoraService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/horas")
public class HoraController {

    @Autowired
    private HoraService horaService;

    @PostMapping
    public Hora createHora(@RequestBody Hora hora) {
        return horaService.createHora(hora);
    }

    @GetMapping
    public List<Hora> getAllHoras() {
        return horaService.getAllHoras();
    }

    @GetMapping("/{id}")
    public ResponseEntity<Hora> getHoraById(@PathVariable Integer id) {
        return horaService.getHoraById(id)
                .map(ResponseEntity::ok)
                .orElseGet(() -> ResponseEntity.notFound().build());
    }

    @PutMapping("/{id}")
    public ResponseEntity<Hora> updateHora(@PathVariable Integer id, @RequestBody Hora horaDetails) {
        Hora updatedHora = horaService.updateHora(id, horaDetails);
        return updatedHora != null ? ResponseEntity.ok(updatedHora) : ResponseEntity.notFound().build();
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteHora(@PathVariable Integer id) {
        horaService.deleteHora(id);
        return ResponseEntity.noContent().build();
    }
}
